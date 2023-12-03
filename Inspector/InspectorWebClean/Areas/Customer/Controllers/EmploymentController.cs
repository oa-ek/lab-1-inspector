namespace InspectorWeb.Areas.Customer.Controllers
{
	/*[Area("Customer")]
	public class EmploymentController : Controller
    {
		private readonly IOrganizationRepository _organizationRepo;
		private readonly IEmploymentRepository _employmentRepo;
        private readonly IUserRepository _userRepo;
        public EmploymentController(
			IOrganizationRepository organizationRepo,
			IEmploymentRepository employmentRepo,
            IUserRepository userRepo)
        {
			_organizationRepo = organizationRepo;
			_employmentRepo = employmentRepo;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
			List<Inspector.Domain.Entities.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return View(organizationList);
        }

		public IActionResult Apply(int? OrgId)
		{
			Employment employment = new Employment();

			employment.OrganizationId = OrgId;

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			employment.UserId = userId;

            _employmentRepo.Add(employment);
			_employmentRepo.Save();

			TempData["success"] = "You have successfuly apply!";

			return RedirectToAction("Index");
		}

		#region API CALLS

		[HttpGet]
		public IActionResult GetAllOrg()
		{
			List<Inspector.Domain.Entities.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return Json(new { data = organizationList });

		}

		#endregion

	}*/
}
