using Inspector.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Inspector.Utility;
using IEmailSender = Inspector.Utility.IEmailSender;
using Inspector.Domain.Repository.IRepository;
using Inspector.Domain.Entities;

namespace InspectorWeb.Areas.Organization.Controllers
{
    [Area("Organization")]
	public class ResponceController : Controller
    {
        private readonly IResponceRepository _responceRepo;
        private readonly IComplaintRepository _complaintRepo;
		private readonly IUserRepository _userRepo;
		private readonly IEmailSender _emailSender;
		public ResponceController(IResponceRepository responceRepo, 
			IComplaintRepository complaintRepo,
			IUserRepository userRepo,
			IEmailSender emailSender)
        {
            _responceRepo = responceRepo;
            _complaintRepo = complaintRepo;
			_userRepo = userRepo;
			_emailSender = emailSender;
        }

        public IActionResult Create(int? ComplaintId, int? OrganizationId, string UserTakeId)
        {
            Responce responce = new Responce();
            responce.ComplaintId = _complaintRepo.Get(u => u.Id == ComplaintId).Id;
			responce.UserTakeId = UserTakeId;
			return View(responce);
        }

        [HttpPost]
        public IActionResult Create(Responce responce, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _responceRepo.Add(responce);
                _responceRepo.Save();

                //sending email for the user when the response is given
                var user = _userRepo.Get(u => u.Id == responce.UserTakeId);
                SendResponseEmail(user.Email, user.OrganizationId);

				TempData["success"] = "Responce and email sent successfully";
				

				Complaint obj = _complaintRepo.Get(u => u.Id == responce.ComplaintId);
                obj.ResponceId = responce.Id;
                obj.Status = "done";
                _complaintRepo.Save();

                return RedirectToAction("Index", "Complaint");
            }
            return View(responce);
        }


		public async Task SendResponseEmail(string email, int? orgID)
		{
			await _emailSender.SendEmailAsync(email, null, null, orgID);
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