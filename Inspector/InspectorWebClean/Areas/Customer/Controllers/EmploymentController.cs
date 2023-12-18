using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;
using Inspector.Application.Features.EmploymentFeatures.Commands.CreateEmploymentCommand;
using Inspector.Application.Features.EmploymentFeatures.Commands.SaveEmploymentCommand;
using Inspector.Application.Features.EmploymentFeatures.Queries.GetAllEmploymentQuery;
using Inspector.Application.Features.EmploymentFeatures.Queries.GetEmploymentQuery;
using Inspector.Application.Features.FileFeatures.Queries.GetFileQuery;
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

		public async Task<IActionResult> IndexToOrg()
		{			
			return View();
		}

		public async Task<IActionResult> Apply(Guid? OrgId)
		{
			Employment employment = new Employment();

			employment.OrganizationId = OrgId;

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			employment.UserId = userId;

            List<Employment> emp = (await _mediator.Send<IEnumerable<Employment>>(new GetAllEmploymentQuery()))
            .Where(item => item.UserId == userId)
            .ToList();

            Employment item = emp.FirstOrDefault();

            if (item == null || item.OrganizationId != OrgId)
			{
                await _mediator.Send(new CreateEmploymentCommand(employment));
                await _mediator.Send(new SaveEmploymentCommand());

                TempData["success"] = "You have successfuly apply!";
            }
			else
			{
                TempData["success"] = "You have already apply!";
            }

			return RedirectToAction("IndexOrg");
		}


		public async Task<IActionResult> ApplyForOrg(Guid? OrgId)
		{
			Employment employment = new Employment();

			//employment.OrganizationId = new Guid();

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			employment.UserId = userId;

			employment.ToOrg = true;

			List<Employment> emp = (await _mediator.Send<IEnumerable<Employment>>(new GetAllEmploymentQuery()))
			.Where(item => item.UserId == userId)
			.ToList();

			Employment item = emp.FirstOrDefault();

			if (item == null)
			{
				await _mediator.Send(new CreateEmploymentCommand(employment));
				await _mediator.Send(new SaveEmploymentCommand());

				TempData["success"] = "You have successfuly apply!";
			}
			else
			{
				TempData["success"] = "You have already apply!";
			}

			return RedirectToAction("IndexToOrg");
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
