using Microsoft.AspNetCore.Mvc;

namespace InspectorWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class HomeController : Controller
	{
		public async Task<IActionResult> Index()
		{			
			return View();
		}
		
	}
}
