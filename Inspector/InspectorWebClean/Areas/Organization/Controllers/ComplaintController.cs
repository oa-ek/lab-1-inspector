using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Domain.Entities;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetUserQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;

namespace InspectorWeb.Areas.Organization.Controllers
{
    [Area("Organization")]
	public class ComplaintController : BaseController
	{
		public ComplaintController(IMediator mediator) : base(mediator) { }

		//for organization
		public async Task<IActionResult> Index()
        {
			var complaintList = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));
			return View(complaintList);
        }

        #region API CALLS

        [HttpGet]
		public async Task<IActionResult> GetAllOrg()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			Guid? orfidfrom = (await _mediator.Send<ApplicationUser>(new GetUserQuery(userId))).OrganizationId;

            List<Complaint> complaintList = (await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User")))
			.Where(item => item.IsArchive == false && item.OrganizationId == orfidfrom)
            .ToList();

            return Json(new { data = complaintList });

        }

        #endregion
    }
}
