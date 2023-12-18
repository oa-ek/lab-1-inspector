using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Inspector.Domain.Entities;
using Inspector.Application.Features.UserFeatures.Queries.GetUserQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Commands.SaveComplaintCommand;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;
using Inspector.Application.Features.ResponseFeatures.Commands.CreateResponseCommand;
using Inspector.Application.Features.CommandFeatures.Commands.SaveResponseCommand;
using Inspector.Utility;
using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inspector.Application.Features.EmploymentFeatures.Queries.GetAllEmploymentQuery;
using Inspector.Application.Features.ResponseFeatures.Queries.GetAllResponseQuery;

namespace InspectorWeb.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class ResponseController : BaseController
	{
		public ResponseController(IMediator mediator) : base(mediator)
		{
		}
	
		public async Task<IActionResult> Index(Guid? id)
        {
			List<Response> responses = (await _mediator.Send<IEnumerable<Response>>(new GetAllResponseQuery()))
			.Where(item => item.ComplaintId == id)
			.ToList();

			Response item = responses.FirstOrDefault();

			return View(item);
		}

    }
}