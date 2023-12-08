using Inspector.Application.Features.CommandFeatures.Commands.SaveResponseCommand;
using Inspector.Application.Features.ComplaintFeatures.Commands.SaveComplaintCommand;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery;
using Inspector.Application.Features.ResponseFeatures.Commands.CreateResponseCommand;
using Inspector.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InspectorWeb.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ResponceController : BaseController
    {
        public ResponceController(IMediator mediator) : base(mediator) { }

        public async Task<IActionResult> Create(Guid? ComplaintId)  
        {
            Response responce = new Response();
            responce.ComplaintId = (await _mediator.Send<Complaint>(new GetComplaintQuery(ComplaintId.Value))).Id;
            return View(responce);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Response responce, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateResponseCommand(responce));
                await _mediator.Send(new SaveResponseCommand());
                TempData["success"] = "Responce sent successfully";

                Complaint obj = await _mediator.Send<Complaint>(new GetComplaintQuery(responce.ComplaintId));
                obj.ResponceId = responce.Id;
                obj.Status = "report";
                await _mediator.Send(new SaveComplaintCommand());

                return RedirectToAction("Index", "Complaint");
            }
            return View(responce);
        }
    }
}