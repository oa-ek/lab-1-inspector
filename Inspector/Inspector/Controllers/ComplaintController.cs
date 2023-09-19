using Inspector.DataAccess.Data;
using Inspector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
			_db.Complaints.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Complaint? complaindb = _db.Complaints.Find(id);
			if (complaindb == null)
			{
				return NotFound();
			}

			_db.Complaints.Remove(complaindb);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}


		

	}
}
