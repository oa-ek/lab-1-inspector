using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Inspector.Domain.Entities;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery;
using Inspector.Application.Features.UserFeatures.Queries.GetUserQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Commands.SaveComplaintCommand;
using Inspector.Application.Features.CommandFeatures.Commands.SaveResponseCommand;
using Inspector.Application.Features.ResponseFeatures.Commands.CreateResponseCommand;
using Inspector.Utility;

namespace InspectorWeb.Areas.Organization.Controllers
{
	[Area("Organization")]
	public class ResponceController : BaseController
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly Inspector.Utility.IEmailSender _emailSender;

		public ResponceController(IMediator mediator, UserManager<IdentityUser> userManager, Inspector.Utility.IEmailSender emailSender) : base(mediator)
		{
			_emailSender = emailSender;
			_userManager = userManager;
		}

		public async Task<IActionResult> Create(Guid? ComplaintId, int? OrganizationId, string UserTakeId)
        {
			Response responce = new Response();
			responce.ComplaintId = (await _mediator.Send<Complaint>(new GetComplaintQuery(ComplaintId.Value))).Id;
			responce.UserTakeId = UserTakeId;
			return View(responce);
		}

        [HttpPost]
        public async Task<IActionResult> Create(Response response, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
				await _mediator.Send(new CreateResponseCommand(response));
				await _mediator.Send(new SaveResponseCommand());

				//sending email for the user when the response is given
				var user = await _mediator.Send<ApplicationUser>(new GetUserQuery(response.UserTakeId));
                SendResponseEmail(user.Email, user.OrganizationId);

				TempData["success"] = "Responce and email sent successfully";


				Complaint obj = await _mediator.Send<Complaint>(new GetComplaintQuery(response.ComplaintId));
				obj.ResponceId = response.Id;
				obj.Status = SC.Status_Complete;// "done";
				await _mediator.Send(new SaveComplaintCommand());

                return RedirectToAction("Index", "Complaint");
            }
            return View(response);
		}


		public async Task SendResponseEmail(string email, Guid? orgID)
		{
			await _emailSender.SendEmailAsync(email, null, null, orgID);
		}

		public async Task<IActionResult> Archive(int? id)
        {
            List<Complaint> complaintList = (await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User")))
            .Where(item => item.IsArchive == true)
            .ToList();

            return View(complaintList);
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