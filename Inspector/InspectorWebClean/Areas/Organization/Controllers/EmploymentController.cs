using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Inspector.Utility;
using Microsoft.AspNetCore.Identity;
using MediatR;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetUserQuery;
using Inspector.Domain.Entities;
using Inspector.Application.Features.EmploymentFeatures.Queries.CreateEmploymentQuery;
using Inspector.Application.Features.UserFeatures.Commands.SaveUserCommand;

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
			await _mediator.Send(new SaveUserCommand());

            return RedirectToAction("Index");
        }

        public async Task ChangeRole(ApplicationUser user)
        {
            try
            {
                //TempData["success"] = "Вщту";

                // Вивід інформації про поточні ролі користувача перед зміною.
                var userRolesBeforeChange = await _userManager.GetRolesAsync(user);
                foreach (var role in userRolesBeforeChange)
                {
                    TempData["success"] += $" Попередні ролі: {role}";
                }

                // Видалення користувача з ролі "SD.Role_Cust".
                await _userManager.RemoveFromRoleAsync(user, SD.Role_Cust);

                // Додавання користувача до ролі "SD.Role_Empl".
                await _userManager.AddToRoleAsync(user, SD.Role_Empl);

                // Оновлення користувача в контексті бази даних.
                await _userManager.UpdateAsync(user);

                // Вивід інформації про поточні ролі користувача після зміни.
                var userRolesAfterChange = await _userManager.GetRolesAsync(user);
                foreach (var role in userRolesAfterChange)
                {
                    TempData["success"] += $" Нові ролі: {role}";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Помилка при зміні ролі: {ex.Message}";
            }
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
