using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.CreateEmploymentQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.CreateFileQuery;
using Inspector.Application.Features.FileFeatures.Queries.SaveEmploymentQuery;
using Inspector.Application.Features.FileFeatures.Queries.SaveFileQuery;
using Inspector.Application.Features.OrganizationFeatures.Queries.AddAllOrganizationQuery;
using Inspector.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InspectorWeb.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class EmploymentController : BaseController
	{
		public EmploymentController(IMediator mediator) : base(mediator)
		{
		}
		public async Task<IActionResult> IndexOrg()
		{				
			var organizationList = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return View(organizationList);
		}

		public async Task<IActionResult> Apply(Guid? OrgId)
		{
			Employment employment = new Employment();

			employment.OrganizationId = OrgId;

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			employment.UserId = userId;

			await _mediator.Send(new CreateEmploymentQuery(employment));
			await _mediator.Send(new SaveEmploymentQuery());

			TempData["success"] = "You have successfuly apply!";

			return RedirectToAction("Index");
		}


		#region API CALLS

		[HttpGet]
		public async Task<IActionResult> GetAllOrg()
		{
			var organizationList = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return Json(new { data = organizationList });

		}

		#endregion

	}
}
