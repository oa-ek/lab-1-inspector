using Inspector.DataAccess.Data;
using Inspector.DataAccess.Repository;
using Inspector.DataAccess.Repository.IRepository;
using Inspector.Models;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
			List<Complaint> complaintList = _complaintRepo.GetAll().ToList();
            return View(complaintList);
        }

		public IActionResult Create()
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

			return View(complaintVC);
		}

        [HttpPost]
		public IActionResult Create(ComplaintVM complaintVM, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				if (file != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string filePath = Path.Combine(wwwRootPath, @"files");

					using (var fileStrem = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
					{
						file.CopyTo(fileStrem);
					}

					complaintVM.Complaint.File = "/files/" + fileName;

				}

				_complaintRepo.Add(complaintVM.Complaint);
				_complaintRepo.Save();
				TempData["success"] = "Complaint created successfuly!";
				return RedirectToAction("Index");
			}
			return View(complaintVM);
		}
	}
}
