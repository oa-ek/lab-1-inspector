using Azure;
using Inspector.DataAccess.Repository.IRepository;
using Inspector.Models;
using Inspector.Models.ViewModels;
using Inspector.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;

namespace InspectorWeb.Areas.Organization.Controllers
{
	[Area("Organization")]
	public class AssignmentController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IComplaintRepository _complaintRepo;
        private readonly IAssignmentRepository _assignmentRepo;
        public AssignmentController(
            IUserRepository userRepo,
            IComplaintRepository complaintRepo,
            IAssignmentRepository assignmentRepo)
        {
            _userRepo = userRepo;
            _complaintRepo = complaintRepo;
            _assignmentRepo = assignmentRepo;
        }

        public IActionResult Create(int? ComplaintId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? orfidfrom = _userRepo.Get(x => x.Id == userId).OrganizationId;

            var userList = _userRepo.GetAll()
            .Where(item => User.IsInRole(SD.Role_Empl) && item.OrganizationId == orfidfrom)
            .ToList();

            AssignmentVM assignmentVM = new()
            {
                UserList = userList.Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                }),
                Assignment = new Assignment()
            };

            assignmentVM.Assignment.ComplaintId = _complaintRepo.Get(u => u.Id == ComplaintId).Id;
            assignmentVM.Assignment.UserGiveId = userId;

            return View(assignmentVM);
        }

        [HttpPost]
        public IActionResult Create(AssignmentVM assignmentVM)
        {
            if (ModelState.IsValid)
            {
                _assignmentRepo.Add(assignmentVM.Assignment);
                TempData["success"] = "Assignment created successfully";
                _assignmentRepo.Save();

                Complaint complaint = _complaintRepo.Get(u => u.Id == assignmentVM.Assignment.ComplaintId);
                _complaintRepo.Get(u => u.Id == assignmentVM.Assignment.ComplaintId).Status = "in process";
                _complaintRepo.Save();

                return RedirectToAction("Index", "Complaint");
            }
            return View();
        }
    }
}