using Inspector.DataAccess.Data;
using Inspector.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InspectorWeb.Controllers
{
    public class ComplaintController: Controller
    {
        private readonly ApplicationDbContext _db;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ComplaintController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment) 
        { 
            _db = db;
			_webHostEnvironment = webHostEnvironment;
		}

        public IActionResult Index()
        {
            List<Complaint> complaintList = _db.Complaints.ToList();
            return View(complaintList);
        }

		public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
		public IActionResult Create(Complaint obj, IFormFile? file)
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

					obj.File = "/files/" + fileName;

				}

				_db.Complaints.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Complaint created successfuly!";
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
