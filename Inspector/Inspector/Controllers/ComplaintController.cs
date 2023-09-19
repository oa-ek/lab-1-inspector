using Inspector.DataAccess.Data;
using Inspector.Models;
using Microsoft.AspNetCore.Mvc;

namespace InspectorWeb.Controllers
{
    public class ComplaintController: Controller
    {
        private readonly ApplicationDbContext _db;
        public ComplaintController(ApplicationDbContext db) 
        { 
            _db = db;
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
		public IActionResult Create(Complaint obj)
		{
			if (ModelState.IsValid)
			{
				_db.Complaints.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index"); 
			}
			return View(obj);
		}
	}
}
