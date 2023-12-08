using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InspectorWeb.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class EmployementController : BaseController
	{
		public EmployementController(IMediator mediator) : base(mediator)
		{
		}
		public async Task<IActionResult> Index()
		{				
			var organizationList = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return View(organizationList);
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
