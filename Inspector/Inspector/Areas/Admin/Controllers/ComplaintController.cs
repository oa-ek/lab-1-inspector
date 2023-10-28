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

namespace InspectorWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ComplaintController : Controller
    {
        private readonly IComplaintRepository _complaintRepo;
        private readonly IOrganizationRepository _organizationRepo;
        private readonly IUserRepository _userRepo;
        public ComplaintController(
            IComplaintRepository complaintRepo,
            IOrganizationRepository organizationRepo, 
            IUserRepository userRepo)
        {
            _complaintRepo = complaintRepo;
            _organizationRepo = organizationRepo;
            _userRepo = userRepo;
        }


        public IActionResult IndexCompl()
        {
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
            return View(complaintList);
        }

        public IActionResult IndexOrg()
        {
            List<Inspector.Models.Organization> organizationList = _organizationRepo.GetAll().ToList();
            return View(organizationList);
        }

        public IActionResult IndexUser()
        {
            List<ApplicationUser> userList = _userRepo.GetAll().ToList();
            return View(userList);
        }

        #region API CALLS

        [HttpGet]
		public IActionResult GetAll()
        {
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
            return Json(new { data = complaintList });

        }

        [HttpGet]
        public IActionResult GetAllOrg()
        {
            List<Inspector.Models.Organization> organizationList = _organizationRepo.GetAll().ToList();
            return Json(new { data = organizationList });

        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            List<ApplicationUser> userList = _userRepo.GetAll().ToList();
            return Json(new { data = userList });

        }

        #endregion
    }
}
