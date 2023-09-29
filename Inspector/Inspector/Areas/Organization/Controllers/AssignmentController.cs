using Azure;
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
            var userList = _userRepo.GetAll()
            .Where(item => item.IsEmployee == true)
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

            return View(assignmentVM);
        }

        [HttpPost]
        public IActionResult Create(AssignmentVM assignmentVM)
        {
            if (ModelState.IsValid)
            {
                _assignmentRepo.Add(assignmentVM.Assignment);
                TempData["success"] = "Assignment created successfully";
                _complaintRepo.Save();
                return RedirectToAction("IndexOrg", "Complaint");
            }
            return View();
        }
    }
}