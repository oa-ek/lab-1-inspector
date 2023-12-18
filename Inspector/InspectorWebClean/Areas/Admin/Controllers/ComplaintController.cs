using Microsoft.AspNetCore.Mvc;
using Inspector.Domain.Entities;
using MediatR;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;
using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
using Inspector.Application.Features.UserFeatures;
using Inspector.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using Inspector.Application.Features.EmploymentFeatures.Queries.GetAllEmploymentQuery;
using System.Security.Claims;
using Inspector.Application.Features.EmploymentFeatures.Commands.DeleteEmploymentCommand;
using Inspector.Application.Features.EmploymentFeatures.Commands.SaveEmploymentCommand;
using Inspector.Application.Features.UserFeatures.Commands.SaveUserCommand;
using Inspector.Application.Features.UserFeatures.Commands.UpdateUSerRoleCommand;
using Inspector.Application.Features.UserFeatures.Queries.GetUserQuery;
using Inspector.Application.Features.OrganizationFeatures.Commands.CreateOrganizationCommand;
using Inspector.Application.Features.OrganizationFeatures.Commands.SaveOrganizationCommand;

namespace InspectorWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ComplaintController : Controller
	{
		private readonly IMediator _mediator;
		public ComplaintController(IMediator mediator)
		{
			_mediator = mediator;
		}

        public async Task<IActionResult> Index()
		{
			var complaints = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));
			return View(complaints);
		}
		public async Task<IActionResult> IndexOrg()
		{
			var organizations = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return View(organizations);
		}

		public async Task<IActionResult> IndexUser()
		{
			var users = await _mediator.Send<IEnumerable<ApplicationUser>>(new GetAllUserQuery("Organization"));
			return View(users);
		}


		// to become an org
		public async Task<IActionResult> IndexEmp()
		{
			var employmentList = (await _mediator.Send<IEnumerable<Employment>>(new GetAllEmploymentQuery(includeProperties: "Organization,User")))
				.Where(item => item.ToOrg == true)
				.ToList();

			return View();

		}

		public async Task<IActionResult> Accept(string userId)
		{
			var user = await _mediator.Send<ApplicationUser>(new GetUserQuery(userId));

			var orgId = Guid.NewGuid();

			Inspector.Domain.Entities.Organization newOrg = new Inspector.Domain.Entities.Organization();
			newOrg.Id = orgId;
			newOrg.Name = user.FullName;
			newOrg.Description = user.FullName;
			await _mediator.Send(new CreateOrganizationCommand(newOrg));
			await _mediator.Send(new SaveOrganizationCommand());

			user.OrganizationId = orgId;
			await _mediator.Send(new UpdateUserRoleCommand(user, "company"));
			await _mediator.Send(new SaveUserCommand());

			List<Employment> emp = (await _mediator.Send<IEnumerable<Employment>>(new GetAllEmploymentQuery()))
			.Where(item => item.UserId == userId)
			.ToList();

			Employment item = emp.FirstOrDefault();

			await _mediator.Send<Employment>(new DeleteEmploymentCommand(item));
			await _mediator.Send(new SaveEmploymentCommand());

			TempData["success"] = "New org was added successfully";

			return RedirectToAction("Index");
		}

		#region API CALLS

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var complaints = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));
			return Json(new { data = complaints });

		}

		[HttpGet]
		public async Task<IActionResult> GetAllOrg()
		{
			var organizations = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return Json(new { data = organizations });
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUser()
		{
			var users = await _mediator.Send<IEnumerable<ApplicationUser>>(new GetAllUserQuery("Organization"));
			return Json(new { data = users });

		}
		#endregion
	}
}
