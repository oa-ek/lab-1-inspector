using Inspector.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InspectorWeb.Areas.User.Controllers
{
	[Area("User")]
	public class ComplaintController : Controller
    {
        private readonly ILogger<ComplaintController> _logger;

        public ComplaintController(ILogger<ComplaintController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}