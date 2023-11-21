using Inspector.DataAccess.Data;
using Inspector.DataAccess.Repository;
using Inspector.DataAccess.Repository.IRepository;
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

namespace InspectorWeb.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class EmploymentController : Controller
    {
		private readonly IOrganizationRepository _organizationRepo;
		private readonly IEmploymentRepository _employmentRepo;
        private readonly IUserRepository _userRepo;
        public EmploymentController(
			IOrganizationRepository organizationRepo,
			IEmploymentRepository employmentRepo,
            IUserRepository userRepo)
        {
			_organizationRepo = organizationRepo;
			_employmentRepo = employmentRepo;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
			List<Inspector.Models.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return View(organizationList);
        }

		public IActionResult Apply(int? OrgId)
		{
			Employment employment = new Employment();

			employment.OrganizationId = OrgId;

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			employment.UserId = userId;

            _employmentRepo.Add(employment);
			_employmentRepo.Save();

			TempData["success"] = "You have successfuly apply!";

			return RedirectToAction("Index");
		}

		#region API CALLS

		[HttpGet]
		public IActionResult GetAllOrg()
		{
			List<Inspector.Models.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return Json(new { data = organizationList });

		}

		#endregion

	}
}
