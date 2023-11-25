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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Inspector.Domain.Repository.IRepository;
using Inspector.Domain.Entities;

namespace InspectorWeb.Areas.Organization.Controllers
{
    [Area("Organization")]
	public class ComplaintController : Controller
    {
        private readonly IComplaintRepository _complaintRepo;
        private readonly IUserRepository _userRepo;
        private readonly IOrganizationRepository _organizationRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ComplaintController(
            IComplaintRepository complaintRepo,
            IUserRepository userRepo,
            IOrganizationRepository organizationRepo,
            IWebHostEnvironment webHostEnvironment)
        {
            _complaintRepo = complaintRepo;
            _userRepo = userRepo;
            _organizationRepo = organizationRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        //for organization
        public IActionResult Index()
        {
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
            return View(complaintList);
        }

        #region API CALLS

        [HttpGet]
		public IActionResult GetAllOrg()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? orfidfrom = _userRepo.Get(x => x.Id == userId).OrganizationId;

            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User")
            .Where(item => item.IsArchive == false && item.OrganizationId == orfidfrom)
            .ToList();

            return Json(new { data = complaintList });

        }

        //maybe in this is no need
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Complaint? complaintToBeDeleted = _complaintRepo.Get(u => u.Id == id);

            if (complaintToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            if (complaintToBeDeleted.File != null)
            {
                var oldImagePath =
                    Path.Combine(_webHostEnvironment.WebRootPath, complaintToBeDeleted.File.TrimStart('/'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _complaintRepo.Remove(complaintToBeDeleted);
            _complaintRepo.Save();

            return Json(new { success = true, message = "deleted" });
        }
        #endregion
    }
}
