using Inspector.DataAccess.Data;
using Inspector.DataAccess.Repository;
using Inspector.Models;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Azure;
using Inspector.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Inspector.Domain.Repository.IRepository;
using Inspector.Domain.Entities;

namespace InspectorWeb.Areas.Organization.Controllers
{
    [Area("Organization")]
	public class EmploymentController : Controller
    {
		private readonly IOrganizationRepository _organizationRepo;
		private readonly IEmploymentRepository _employmentRepo;
        private readonly IUserRepository _userRepo;
        private readonly UserManager<IdentityUser> _userManager;
        
        public EmploymentController(
			IOrganizationRepository organizationRepo,
			IEmploymentRepository employmentRepo,
            IUserRepository userRepo,
            UserManager<IdentityUser> userManager)
        {
			_organizationRepo = organizationRepo;
			_employmentRepo = employmentRepo;
            _userRepo = userRepo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var currentOrgId = _userRepo.Get(u => u.Id == userId).OrganizationId;

            List<Employment> employmentList = _employmentRepo.GetAll(includeProperties: "Organization,User")
                .Where(item => item.OrganizationId == currentOrgId)
                .ToList();

            return View(employmentList);

        }

        public IActionResult Accept(string userId)
        {
            var user = _userRepo.Get(u => u.Id == userId);

            var orgId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentOrgId = _userRepo.Get(u => u.Id == orgId).OrganizationId;

            user.OrganizationId = currentOrgId;
            _userRepo.Save();

            // Викликайте функцію ChangeRole, щоб змінити роль користувача.
            //ChangeRole(user);

            //TempData["success"] = "User accepted successfully!";

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
		public IActionResult GetAllEmployments()
		{
            //List<Employment> employmentList = _employmentRepo.GetAll(includeProperties: "Organization,User").ToList();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentOrgId = _userRepo.Get(u => u.Id == userId).OrganizationId;

            List<Employment> employmentList = _employmentRepo.GetAll(includeProperties: "Organization,User")
                .Where(item => item.OrganizationId == currentOrgId)
                .ToList();

            return Json(new { data = employmentList });

		}

		#endregion

	}
}
