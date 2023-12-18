using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Inspector.Domain.Entities;
using Inspector.Application.Features.UserFeatures.Queries.GetUserQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Commands.SaveComplaintCommand;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;
using Inspector.Application.Features.ResponseFeatures.Commands.CreateResponseCommand;
using Inspector.Application.Features.CommandFeatures.Commands.SaveResponseCommand;
using Inspector.Utility;
using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inspector.Application.Features.ResponseFeatures.Queries.GetAllResponseQuery;
using Inspector.Application.Features.ResponseFeatures.Commands.UpdateResponseCommand;

namespace InspectorWeb.Areas.Organization.Controllers
{
	[Area("Organization")]
	public class ResponseController : BaseController
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly Inspector.Utility.IEmailSender _emailSender;

		public ResponseController(IMediator mediator, UserManager<IdentityUser> userManager, Inspector.Utility.IEmailSender emailSender) : base(mediator)
		{
			_emailSender = emailSender;
			_userManager = userManager;
		}

		public async Task<IActionResult> Create(Guid? ComplaintId, int? OrganizationId, string UserTakeId)
        {
			Response responce = new Response();

			List<Response> responses = (await _mediator.Send<IEnumerable<Response>>(new GetAllResponseQuery()))
			.Where(item => item.ComplaintId == ComplaintId)
			.ToList();

			responce = responses.FirstOrDefault();

			if (responce == null)
			{
				//create
				responce = new Response();
				responce.ComplaintId = (await _mediator.Send<Complaint>(new GetComplaintQuery(ComplaintId.Value))).Id;
				responce.UserTakeId = UserTakeId;
				return View(responce);
			}
			else
			{
				//update
				return View(responce);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Create(Response response, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
				if (response.Id == Guid.Empty)
				{
					await _mediator.Send(new CreateResponseCommand(response));
				}
				else
				{
					await _mediator.Send(new UpdateResponseCommand(response));
				}

				await _mediator.Send(new SaveResponseCommand());

				//sending email for the user when the response is given
				var user = await _mediator.Send<ApplicationUser>(new GetUserQuery(response.UserTakeId));
                SendResponseEmail(user.Email, user.OrganizationId, response.ComplaintId);

				TempData["success"] = "Responce and email sent successfully";


				Complaint obj = await _mediator.Send<Complaint>(new GetComplaintQuery(response.ComplaintId));
				obj.ResponceId = response.Id;
				obj.Status = SC.Status_Close;// "done";
				await _mediator.Send(new SaveComplaintCommand());

                return RedirectToAction("Index", "Complaint");
            }
            return View(response);
		}


		public async Task SendResponseEmail(string email, Guid? orgID, Guid? complaintId)
		{
			await _emailSender.SendEmailAsync(email, null, null, orgID, complaintId);
		}

		public async Task<IActionResult> Archive(Guid? id)
        {
            List<Complaint> complaintList = (await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User")))
            .Where(item => item.IsArchive == true)
            .ToList();

            return View("Archive", complaintList);
		}

        public async Task<IActionResult> ToArchive(Guid? ComplaintId)
		{
			Complaint? complaintToBeArchived = await _mediator.Send<Complaint>(new GetComplaintQuery(ComplaintId.Value));

            complaintToBeArchived.IsArchive = true;
			await _mediator.Send(new SaveComplaintCommand());

			return RedirectToAction("Index", "Complaint");
		}


		#region API CALLS

		[HttpGet]
		public async Task<IActionResult> GetArchive()
        {
            List<Complaint> complaintList = (await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User")))
			.Where(item => item.IsArchive == true)
            .ToList();

            return Json(new { data = complaintList });

        }
        #endregion
    }
}