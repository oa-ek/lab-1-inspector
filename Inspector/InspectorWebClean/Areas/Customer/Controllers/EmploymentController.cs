using Inspector.Application.Features.EmploymentFeatures.Commands.CreateEmploymentCommand;
using Inspector.Application.Features.EmploymentFeatures.Commands.SaveEmploymentCommand;
using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
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

			await _mediator.Send(new CreateEmploymentCommand(employment));
			await _mediator.Send(new SaveEmploymentCommand());

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
