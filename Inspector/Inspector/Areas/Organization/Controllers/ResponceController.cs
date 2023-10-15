using Inspector.DataAccess.Repository.IRepository;
using Inspector.Models;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace InspectorWeb.Areas.Employee.Controllers
{
	[Area("Employee")]
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
                obj.Status = "done";
                _complaintRepo.Save();

                return RedirectToAction("Index", "Complaint");
            }
            return View(responce);
        }
    }
}