using Microsoft.AspNetCore.Mvc;
using Inspector.Domain.Entities;
using MediatR;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;
using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
using Inspector.Application.Features.UserFeatures;
using Inspector.Application.Features.UserFeatures.Queries.GetAllUserQuery;

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
			/*List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
            return View(complaintList);*/
			var complaints = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));
			return View(complaints);
		}
		public async Task<IActionResult> IndexOrg()
		{
			/*List<Inspector.Domain.Entities.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return View(organizationList);*/
			var organizations = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return View(organizations);
		}

		public async Task<IActionResult> IndexUser()
		{
			/*List<ApplicationUser> userList = _userRepo.GetAll().ToList();
			return View(userList);*/
			var users = await _mediator.Send<IEnumerable<UserReadShortDto>>(new GetAllUserQuery("Organization"));
			return View(users);
		}

		#region API CALLS

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			/*List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
			return Json(new { data = complaintList });*/
			var complaints = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));
			return Json(new { data = complaints });

		}

		[HttpGet]
		public async Task<IActionResult> GetAllOrg()
		{
			/*List<Inspector.Domain.Entities.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return Json(new { data = organizationList });*/
			var organizations = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return Json(new { data = organizations });
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUser()
		{
			/*List<ApplicationUser> userList = _userRepo.GetAll().ToList();
			return Json(new { data = userList });*/
			var users = await _mediator.Send<IEnumerable<UserReadShortDto>>(new GetAllUserQuery("Organization"));
			return Json(new { data = users });

		}
		#endregion
	}
}
