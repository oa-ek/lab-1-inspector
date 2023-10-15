using Inspector.DataAccess.Repository.IRepository;
using Inspector.Models;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace InspectorWeb.Areas.Organization.Controllers
{
	[Area("Organization")]
	public class ResponceController : Controller
    {
        private readonly IResponceRepository _responceRepo;
        private readonly IComplaintRepository _complaintRepo;
        public ResponceController(IResponceRepository responceRepo, IComplaintRepository complaintRepo)
        {
            _responceRepo = responceRepo;
            _complaintRepo = complaintRepo;
        }

        public IActionResult Create(int? ComplaintId)
        {
            Responce responce = new Responce();
            responce.ComplaintId = _complaintRepo.Get(u => u.Id == ComplaintId).Id;
            return View(responce);
        }

        [HttpPost]
        public IActionResult Create(Responce responce, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _responceRepo.Add(responce);
                _responceRepo.Save();
                TempData["success"] = "Responce sent successfully";

                Complaint obj = _complaintRepo.Get(u => u.Id == responce.ComplaintId);
                obj.ResponceId = responce.Id;
                obj.Status = "report";
                _complaintRepo.Save();

                return RedirectToAction("Index", "Complaint");
            }
            return View(responce);
        }

        public IActionResult Archive(int? id)
        {
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User")
            .Where(item => item.IsArchive == true)
            .ToList();

            return View(complaintList);
        }

        public IActionResult ToArchive(int? ComplaintId)
        {
            Complaint? complaintToBeArchived = _complaintRepo.Get(u => u.Id == ComplaintId);

            complaintToBeArchived.IsArchive = true;
            _complaintRepo.Save();

			return RedirectToAction("Index", "Complaint");
		}


		#region API CALLS

		[HttpGet]
        public IActionResult GetArchive()
        {
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User")
            .Where(item => item.IsArchive == true)
            .ToList();

            return Json(new { data = complaintList });

        }
        #endregion
    }
}