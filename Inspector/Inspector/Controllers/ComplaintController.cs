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

namespace InspectorWeb.Controllers
{
    public class ComplaintController: Controller
    {
		private readonly IComplaintRepository _complaintRepo;
		private readonly IOrganizationRepository _organizationRepo;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ComplaintController(
			IComplaintRepository complaintRepo,
			IOrganizationRepository organizationRepo,
			IWebHostEnvironment webHostEnvironment) 
        {
			_complaintRepo = complaintRepo;
			_organizationRepo = organizationRepo;
			_webHostEnvironment = webHostEnvironment;
		}

        public IActionResult Index()
		{
			List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization").ToList();
            return View(complaintList);
        }

		public IActionResult Upsert(int? id)
		{
			ComplaintVM complaintVC = new()
			{
				OrganizationList = _organizationRepo.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Complaint = new Complaint()
			};

			if (id == null || id == 0)
			{
				//create
				return View(complaintVC);
			}
			else
			{
				//update
				complaintVC.Complaint = _complaintRepo.Get(u => u.Id == id);
				return View(complaintVC);
			}
		}

		[HttpPost]
		public IActionResult Upsert(ComplaintVM complaintVM, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				if (file != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string filePath = Path.Combine(wwwRootPath, @"files");

					if (!String.IsNullOrEmpty(complaintVM.Complaint.File))
					{
						var oldImagePath =
							Path.Combine(wwwRootPath, complaintVM.Complaint.File.TrimStart('/'));

						if (System.IO.File.Exists(oldImagePath))
						{
							System.IO.File.Delete(oldImagePath);
						}
					}

					using (var fileStrem = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
					{
						file.CopyTo(fileStrem);
					}

					complaintVM.Complaint.File = "/files/" + fileName;

				}

				if (complaintVM.Complaint.Id == 0)
				{
					_complaintRepo.Add(complaintVM.Complaint);
				}
				else
				{
					_complaintRepo.Update(complaintVM.Complaint);
				}

				_complaintRepo.Save();
				TempData["success"] = "Complaint created successfully";
				return RedirectToAction("Index");
			}
			else
			{
				complaintVM.OrganizationList = _organizationRepo.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				});

				return View(complaintVM);
			}
		}

        public ActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Complaint? complaindb = _complaintRepo.Get(u => u.Id == id);
			if (complaindb == null)
			{
				return NotFound();
			}

			_complaintRepo.Remove(complaindb);
			_complaintRepo.Save();
			return RedirectToAction("Index");
		}


		#region API CALLS

		[HttpGet]
		public IActionResult GetAll()
		{
			/*var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.Preserve
			};*/

			//string json = JsonSerializer.Serialize(new { data = complaintList }, options);

			List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization").ToList();
			return Json(new { data = complaintList });

		}
		#endregion
	}
}
