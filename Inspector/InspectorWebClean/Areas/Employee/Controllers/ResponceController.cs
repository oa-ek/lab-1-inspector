using Inspector.Application.Features.ComplaintFeatures.Queries.AddComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.CreateFileQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.CreateResponseQuery;
using Inspector.Application.Features.FileFeatures.Queries.SaveComplaintQuery;
using Inspector.Application.Features.FileFeatures.Queries.SaveFileQuery;
using Inspector.Application.Features.FileFeatures.Queries.SaveResponseQuery;
using Inspector.Domain.Entities;
using Inspector.Models;
using Inspector.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

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
                await _mediator.Send(new CreateResponseQuery(responce));
                await _mediator.Send(new SaveResponseQuery());
                TempData["success"] = "Responce sent successfully";

                Complaint obj = await _mediator.Send<Complaint>(new GetComplaintQuery(responce.ComplaintId));
                obj.ResponceId = responce.Id;
                obj.Status = "report";
                await _mediator.Send(new SaveComplaintQuery());

                return RedirectToAction("Index", "Complaint");
            }
            return View(responce);
        }
    }
}