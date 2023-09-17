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
    }
}
