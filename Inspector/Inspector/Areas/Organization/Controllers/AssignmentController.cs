using Azure;
using Inspector.Models;
using Inspector.Models.ViewModels;
using Inspector.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;
using Inspector.Utility;
using Microsoft.AspNetCore.Identity;
using Inspector.Domain.Repository.IRepository;
using Inspector.Domain.Entities;

namespace InspectorWeb.Areas.Organization.Controllers
{
    [Area("Organization")]
	public class AssignmentController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IComplaintRepository _complaintRepo;
        private readonly IAssignmentRepository _assignmentRepo;
        private readonly Inspector.Utility.IEmailSender _emailSender;
		private readonly UserManager<IdentityUser> _userManager;
		public AssignmentController(
            IUserRepository userRepo,
            IComplaintRepository complaintRepo,
            IAssignmentRepository assignmentRepo,
			Inspector.Utility.IEmailSender emailSender,
			UserManager<IdentityUser> userManager)
        {
            _userRepo = userRepo;
            _complaintRepo = complaintRepo;
            _assignmentRepo = assignmentRepo;
            _emailSender = emailSender;
			_userManager = userManager;
		}

        public IActionResult Create(int? ComplaintId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? orfidfrom = _userRepo.Get(x => x.Id == userId).OrganizationId;

			var userList = _userRepo.GetAll()
			 .Where(item => _userManager.IsInRoleAsync(item, SD.Role_Empl).Result && item.OrganizationId == orfidfrom)
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

				var user = _userRepo.Get(u => u.Id == assignmentVM.Assignment.UserTakeId);
				SendResponseEmail(user.Email, user.OrganizationId);

				TempData["success"] = "Assignment created successfully";
                _assignmentRepo.Save();

                Complaint complaint = _complaintRepo.Get(u => u.Id == assignmentVM.Assignment.ComplaintId);
                _complaintRepo.Get(u => u.Id == assignmentVM.Assignment.ComplaintId).Status = "in process";
                _complaintRepo.Save();

                return RedirectToAction("Index", "Complaint");
            }
            return View();
        }

		public async Task SendResponseEmail(string email, int? orgID)
        {
			await _emailSender.SendEmailAsync(email, null, null, orgID);
		}
	}
}