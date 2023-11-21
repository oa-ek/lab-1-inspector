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

namespace InspectorWeb.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class EmployementController : Controller
    {
		private readonly IOrganizationRepository _organizationRepo;
		public EmployementController(
			IOrganizationRepository organizationRepo)
        {
			_organizationRepo = organizationRepo;
        }

        public IActionResult Index()
        {
			List<Inspector.Models.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return View(organizationList);
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
