using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Inspector.Utility;
using Microsoft.AspNetCore.Identity;
using MediatR;
using Inspector.Application.Features.UserFeatures.Queries.GetUserQuery;
using Inspector.Domain.Entities;
using Inspector.Application.Features.UserFeatures.Commands.SaveUserCommand;
using Inspector.Application.Features.UserFeatures.Commands.UpdateUSerRoleCommand;
using Inspector.Application.Features.EmploymentFeatures.Queries.GetAllEmploymentQuery;
using Inspector.Application.Features.EmploymentFeatures.Commands.DeleteEmploymentCommand;
using Inspector.Application.Features.EmploymentFeatures.Commands.SaveEmploymentCommand;

namespace InspectorWeb.Areas.Organization.Controllers
{
    [Area("Organization")]
	public class EmploymentController : BaseController
	{
		private readonly UserManager<IdentityUser> _userManager;
		public EmploymentController(IMediator mediator, UserManager<IdentityUser> userManager) : base(mediator) 
        {
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var currentOrgId = (await _mediator.Send<ApplicationUser>(new GetUserQuery(userId))).OrganizationId;

			var employmentList = (await _mediator.Send<IEnumerable<Employment>>(new GetAllEmploymentQuery(includeProperties: "Organization,User")))
                .Where(item => item.OrganizationId == currentOrgId)
                .ToList();

            return View(employmentList);

        }

        public async Task<IActionResult> Accept(string userId)
        {
            var user = await _mediator.Send<ApplicationUser>(new GetUserQuery(userId));

			var orgId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var currentOrgId = (await _mediator.Send<ApplicationUser>(new GetUserQuery(orgId))).OrganizationId;

			user.OrganizationId = currentOrgId;
			await _mediator.Send(new UpdateUserRoleCommand(user, "employee"));
			await _mediator.Send(new SaveUserCommand());

			List<Employment> emp = (await _mediator.Send<IEnumerable<Employment>>(new GetAllEmploymentQuery()))
			.Where(item => item.UserId == userId)
			.ToList();

			Employment item = emp.FirstOrDefault();

			await _mediator.Send<Employment>(new DeleteEmploymentCommand(item));
			await _mediator.Send(new SaveEmploymentCommand());

			TempData["success"] = "Employment was successfully";

			return RedirectToAction("Index");
        }

        #region API CALLS

        [HttpGet]
		public async Task<IActionResult> GetAllEmployments()
		{
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var currentOrgId = (await _mediator.Send<ApplicationUser>(new GetUserQuery(userId))).OrganizationId;

			List<Employment> employmentList = (await _mediator.Send<IEnumerable<Employment>>(new GetAllEmploymentQuery(includeProperties: "Organization,User")))
				.Where(item => item.OrganizationId == currentOrgId)
                .ToList();

            return Json(new { data = employmentList });

		}

		#endregion

	}
}
