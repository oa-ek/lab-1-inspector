using Microsoft.AspNetCore.Mvc;
using Inspector.Domain.Entities;
using MediatR;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Features.OrganizationFeatures.Queries.AddAllOrganizationQuery;

namespace InspectorWeb.Controllers
{
	public class ComplaintController : Controller
    {
        private readonly IMediator _mediator;
        public ComplaintController(IMediator mediator)  
        {
            _mediator = mediator;
        }

		public async Task<IActionResult> Index()
        {
            /*List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
            return View(complaintList);*/
            var complaints = await _mediator.Send<IEnumerable<ComplaintReadShortDto>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));
            return View(complaints);
        }
		public async Task<IActionResult> IndexOrg()
		{
			/*List<Inspector.Domain.Entities.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return View(organizationList);*/
			var organizations = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return View(organizations);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			/*List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
			return Json(new { data = complaintList });*/
			var complaints = await _mediator.Send<IEnumerable<ComplaintReadShortDto>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));
			return Json(new { data = complaints });

		}

		[HttpGet]
		public async Task<IActionResult> GetAllOrg()
		{
			/*List<Inspector.Domain.Entities.Organization> organizationList = _organizationRepo.GetAll().ToList();
			return Json(new { data = organizationList });*/
			var organizations = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery());
			return Json(new { data = organizations });
		}

		/*public IActionResult IndexOrg()
        {
            List<Inspector.Domain.Entities.Organization> organizationList = _organizationRepo.GetAll().ToList();
            return View(organizationList);
        }

        public IActionResult IndexUser()
        {
            List<ApplicationUser> userList = _userRepo.GetAll().ToList();
            return View(userList);
        }

        #region API CALLS

        [HttpGet]
		public IActionResult GetAll()
        {
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
            return Json(new { data = complaintList });

        }

        [HttpGet]
        public IActionResult GetAllOrg()
        {
            List<Inspector.Domain.Entities.Organization> organizationList = _organizationRepo.GetAll().ToList();
            return Json(new { data = organizationList });

        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            List<ApplicationUser> userList = _userRepo.GetAll().ToList();
            return Json(new { data = userList });

        }

        #endregion*/
	}
}
