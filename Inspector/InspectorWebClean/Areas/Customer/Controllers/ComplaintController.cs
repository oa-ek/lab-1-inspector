using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Inspector.Domain.Entities;
using MediatR;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Models.ViewModels;
using Inspector.Application.Features.OrganizationFeatures.Queries.AddAllOrganizationQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.CreateComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.UpdateComplaintQuery;
using Inspector.Application.Features.FileFeatures.Queries.GetAllFilesQuery;
using Inspector.Application.Features.FileFeatures.Queries.DeleteFileQuery;
using Inspector.Application.Features.FileFeatures.Queries.SaveFileQuery;
using Inspector.Application.Features.FileFeatures.Queries.SaveComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.CreateFileQuery;

namespace InspectorWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ComplaintController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ComplaintController(
            IWebHostEnvironment webHostEnvironment,
            IMediator mediator
            ) : base(mediator)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        //complaint for user
        public  async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

			var complaintList = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));

			if (!string.IsNullOrEmpty(userId))
            {
                List<Complaint> filteredComplaints = new List<Complaint>();

                foreach (var item in complaintList)
                {
                    if (item.UserId == userId)
                    {
                        filteredComplaints.Add(item);
                    }
                }

                complaintList = filteredComplaints;
                return View(complaintList);
            }

            return View(complaintList);
        }

		public async Task<IActionResult> Upsert(Guid? id)
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

			if (id == null || id == Guid.Empty)
			{
				//create
				return View(complaintVM);
			}
			else
			{
				//update
				complaintVM.Complaint = await _mediator.Send<Complaint>(new GetComplaintQuery(id.Value));
				return View(complaintVM);
			}
		}

		//зробити так, щоб бачити які файли вже є на цю скаргу при редагуванні
		//ізараз якщо я маю файли на скаргу, при оновлені вони видаляться, то зробити так щоб користувач то вручну робив і може якийсь видаляв а якийсь ні
		[HttpPost]
		public async Task<IActionResult> Upsert(ComplaintVM complaintVM, List<IFormFile>? files)
		{
			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;

				if (complaintVM.Complaint.Id == Guid.Empty)
				{
					complaintVM.Complaint.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
					//complaintVM.Complaint = await _mediator.Send<Complaint>(new CreateComplaintQuery(complaintVM.Complaint));
					await _mediator.Send<Complaint>(new CreateComplaintQuery(complaintVM.Complaint));
					TempData["success"] = "Complaint created successfully";
				}
				else
				{
					complaintVM.Complaint.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
					await _mediator.Send<Complaint>(new UpdateComplaintQuery(complaintVM.Complaint));

					//видалення файлів які були збережені на цю скаргу раніше
					var complaintFiles = (await _mediator.Send<IEnumerable<ComplaintFile>>(new GetAllFilesQuery())).Where(cf => cf.Id == complaintVM.Complaint.Id).ToList();

					foreach (var compFile in complaintFiles)
					{
						if (!string.IsNullOrEmpty(compFile.FilePath))
						{
							var oldImagePath = Path.Combine(wwwRootPath, compFile.FilePath.TrimStart('/'));

							if (System.IO.File.Exists(oldImagePath))
							{
								System.IO.File.Delete(oldImagePath);
                                await _mediator.Send(new DeleteFileQuery(compFile));
								await _mediator.Send(new SaveFileQuery());
							}
						}
					}

					TempData["success"] = "Complaint update successfully";
				}

				await _mediator.Send(new SaveComplaintQuery());

				if (files != null && files.Count > 0)
				{
					foreach (var file in files)
					{
						if (file != null && file.Length > 0)
						{
							string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
							string filePath = Path.Combine(wwwRootPath, @"files");


							using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
							{
								file.CopyTo(fileStream);
							}

							var complaintFile = new ComplaintFile
							{
								FileName = fileName,
								FilePath = "/files/" + fileName,
								ComplaintId = complaintVM.Complaint.Id
							};

							await _mediator.Send(new CreateFileQuery(complaintFile));
							await _mediator.Send(new SaveFileQuery());
						}
					}
				}

				return RedirectToAction("Index");
			}
			else
			{
                complaintVM.OrganizationList = (await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllOrganizationQuery()))
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

				return View(complaintVM);
			}
		}

		public async Task<IActionResult> GetAll()
		{
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var complaintList = await _mediator.Send<IEnumerable<Complaint>>(new GetAllComplaintQuery(includeProperties: "Organization,User"));

			if (!string.IsNullOrEmpty(userId))
			{
				List<Complaint> filteredComplaints = new List<Complaint>();

				foreach (var item in complaintList)
				{
					if (item.UserId == userId)
					{
						filteredComplaints.Add(item);
					}
				}

				complaintList = filteredComplaints;
			}

			return Json(new { data = complaintList });
		}


		#region API CALLS

		//[HttpGet]
		/*
        //json не підтягує поки іншу область, потім видалити це
        [HttpGet]
        public IActionResult GetAllOrg()
        {
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User")
            .Where(item => item.IsArchive == false)
            .ToList();

            return Json(new { data = complaintList });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Invalid ID" });
            }

            Complaint complaintToBeDeleted = _complaintRepo.Get(u => u.Id == id);

            if (complaintToBeDeleted == null)
            {
                return Json(new { success = false, message = "Complaint not found" });
            }

            List<ComplaintFile> relatedFiles = _complaintFileRepo.GetAll().Where(cf => cf.ComplaintId == id).ToList();

            foreach (var file in relatedFiles)
            {
                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, file.FilePath.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _complaintFileRepo.Remove(file);
            }

            _complaintRepo.Remove(complaintToBeDeleted);

            _complaintRepo.Save();

            return Json(new { success = true, message = "Complaint and related files deleted" });
        }*/

		#endregion

	}
}
