using Microsoft.AspNetCore.Mvc;
using Inspector.Domain.Entities;
using MediatR;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;

namespace InspectorWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class ComplaintController : BaseController
    {
		/*private readonly IMediator _mediator;
		public ComplaintController(IMediator mediator)
		{
			_mediator = mediator;
		}*/

		public ComplaintController(IMediator mediator) : base(mediator)
		{
		}
		public async Task<IActionResult> Index()
        {
            /*List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
            return View(complaintList);*/
            var complaints = await _mediator.Send<IEnumerable<ComplaintReadShortDto>>(new GetAllComplaintQuery());
            return View(complaints);
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
