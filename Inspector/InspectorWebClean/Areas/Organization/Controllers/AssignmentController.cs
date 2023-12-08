using Inspector.Models.ViewModels;
using Inspector.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MediatR;
using Inspector.Domain.Entities;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetUserQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Commands.SaveComplaintCommand;
using Inspector.Application.Features.AssignmentFeatures.Commands.CreateAssignmentCommand;
using Inspector.Application.Features.AssignmentFeatures.Commands.SaveAssignmentCommand;
using Inspector.Application.Features.UserFeatures.Queries.GetAllUserQuery;

namespace InspectorWeb.Areas.Organization.Controllers
{
	[Area("Organization")]
	public class AssignmentController : BaseController
	{
		//забрати це звідси 
		private readonly UserManager<IdentityUser> _userManager;
		private readonly Inspector.Utility.IEmailSender _emailSender;

		public AssignmentController(IMediator mediator, UserManager<IdentityUser> userManager, Inspector.Utility.IEmailSender emailSender) : base(mediator) 
		{
			_emailSender = emailSender;
			_userManager = userManager;
		}

		public async Task<IActionResult> Create(Guid? ComplaintId)
        {
			string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid? orfidfrom = (await _mediator.Send<ApplicationUser>(new GetUserQuery(userId))).OrganizationId;

			var userList = (await _mediator.Send<IEnumerable<UserReadShortDto>>(new GetAllUserQuery()))
			 .Where(item => _userManager.IsInRoleAsync(item, SD.Role_Empl).Result && item.OrganizationId == orfidfrom)
			 .ToList();

			AssignmentVM assignmentVM = new()
			{
				UserList = userList.Select(u => new SelectListItem
				{
					Text = u.FullName,
					Value = u.Id.ToString()
				}),
				Assignment = new Assignment()
			};

			assignmentVM.Assignment.ComplaintId = (await _mediator.Send<Complaint>(new GetComplaintQuery(ComplaintId.Value))).Id;
			assignmentVM.Assignment.UserGiveId = userId;

			return View(assignmentVM);
        }

		[HttpPost]
		public async Task<IActionResult> Create(AssignmentVM assignmentVM)
		{
			if (ModelState.IsValid)
			{
				await _mediator.Send(new CreateAssignmentCommand(assignmentVM.Assignment));
				
				var user = await _mediator.Send<ApplicationUser>(new GetUserQuery(assignmentVM.Assignment.UserTakeId));
				SendResponseEmail(user.Email, user.OrganizationId);

				TempData["success"] = "Assignment created successfully";
				await _mediator.Send(new SaveAssignmentCommand());

				Complaint complaint = await _mediator.Send<Complaint>(new GetComplaintQuery(assignmentVM.Assignment.ComplaintId));
				complaint.Status = "in process";
				await _mediator.Send(new SaveComplaintCommand());

				return RedirectToAction("Index", "Complaint");
			}
			return View();
		}

		public async Task SendResponseEmail(string email, Guid? orgID)
		{
			await _emailSender.SendEmailAsync(email, null, null, orgID);
		}
	}
}