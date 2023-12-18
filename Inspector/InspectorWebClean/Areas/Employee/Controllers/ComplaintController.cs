using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;
using Inspector.Domain.Entities;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery;
using Inspector.Application.Features.AssignmentFeatures.Queries.GetAllAssignmentQuery;
using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
using Inspector.Application.Features.FileFeatures.Queries.GetAllFilesQuery;

namespace InspectorWeb.Areas.Employee.Controllers
{
    [Area("Employee")]
	public class ComplaintController : BaseController
    {
        public ComplaintController(IMediator mediator) : base(mediator){ }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var assignments = await _mediator.Send<IEnumerable<Assignment>>((new GetAllAssignmentQuery()));
            var complaintList = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));

            if (!string.IsNullOrEmpty(userId))
            {
                List<Assignment> filteredAssignments = new List<Assignment>();
                List<Complaint> filteredComplaints = new List<Complaint>();

                foreach (var item in assignments)
                {
                    if (item.UserTakeId == userId)
                    {
                        filteredAssignments.Add(item);
                    }
                }

                foreach (var item in complaintList)
                {
                    foreach (var assignment in filteredAssignments)
                    {
                        if (item.Id == assignment.ComplaintId)
                        {
                            filteredComplaints.Add(item);
                        }
                    }
                }

                complaintList = filteredComplaints;
                return View(complaintList);
            }

            return View(complaintList);
        }

        public async Task<IActionResult> Info(Guid? ComplaintId)
        {
            ComplaintVM complaintVM = new()
            {
                OrganizationList = (await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery()))
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Complaint = new Complaint()
            };

            complaintVM.Complaint = await _mediator.Send<Complaint>(new GetComplaintQuery(ComplaintId.Value));
            return View(complaintVM);
        }

		#region API CALLS
		[HttpGet]
		public async Task<IActionResult> GetAllFiles(Guid? complaintID)
		{

			var fileList = await _mediator.Send<IEnumerable<ComplaintFile>>(new GetAllFilesQuery());


			List<ComplaintFile> filteredFiles = new List<ComplaintFile>();

			foreach (var item in fileList)
			{
				if (item.ComplaintId == complaintID)
				{
					filteredFiles.Add(item);
				}
			}

			return Json(new { data = filteredFiles });
		}

		[HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var assignments = await _mediator.Send<IEnumerable<Assignment>>((new GetAllAssignmentQuery()));
            var complaintList = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));

            if (!string.IsNullOrEmpty(userId))
            {
                List<Assignment> filteredAssignments = new List<Assignment>();
                List<Complaint> filteredComplaints = new List<Complaint>();

                foreach (var item in assignments)
                {
                    if (item.UserTakeId == userId)
                    {
                        filteredAssignments.Add(item);
                    }
                }

                foreach (var item in complaintList)
                {
                    foreach (var assignment in filteredAssignments)
                    {
                        if (item.Id == assignment.ComplaintId)
                        {
                            filteredComplaints.Add(item);
                        }
                    }
                }

                complaintList = filteredComplaints;
            }

            return Json(new { data = complaintList });
        }
        #endregion
    }
}
