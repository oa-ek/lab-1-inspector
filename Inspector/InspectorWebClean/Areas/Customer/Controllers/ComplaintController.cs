using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Inspector.Domain.Entities;
using MediatR;
using Inspector.Models.ViewModels;
using Inspector.Application.Features.FileFeatures.Queries.GetAllFilesQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Commands.CreateComplaintCommand;
using Inspector.Application.Features.ComplaintFeatures.Commands.UpdateComplaintCommand;
using Inspector.Application.Features.ComplaintFeatures.Commands.SaveComplaintCommand;
using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
using Inspector.Application.Features.FileFeatures.Commands.DeleteFileCommand;
using Inspector.Application.Features.FileFeatures.Commands.SaveFileCommand;
using Inspector.Application.Features.FileFeatures.Commands.CreateFileCommand;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Inspector.Application.Features.ComplaintFeatures.Commands.DeleteComplaintCommand;
using Inspector.Application.Features.FileFeatures.Queries.GetFileQuery;

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
				complaintVM.Complaint = await _mediator.Send<Complaint>(new GetComplaintQuery(id.Value, "ComplaintFiles"));
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
					await _mediator.Send<Complaint>(new CreateComplaintCommand(complaintVM.Complaint));
					TempData["success"] = "Complaint created successfully";
				}
				else
				{
					complaintVM.Complaint.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
					await _mediator.Send<Complaint>(new UpdateComplaintCommand(complaintVM.Complaint));

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
                                await _mediator.Send(new DeleteFileCommand(compFile));
								await _mediator.Send(new SaveFileCommand());
							}
						}
					}

					TempData["success"] = "Complaint update successfully";
				}
				await _mediator.Send(new SaveComplaintCommand());

                if (files != null && files.Count > 0)
                {
                    string filesDirectoryPath = Path.Combine(wwwRootPath, @"files");

                    // Ensure the "files" directory exists, create it if not
                    if (!Directory.Exists(filesDirectoryPath))
                    {
                        Directory.CreateDirectory(filesDirectoryPath);
                    }

                    foreach (var file in files)
                    {
                        if (file != null && file.Length > 0)
                        {
                            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            string filePath = Path.Combine(filesDirectoryPath, fileName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                            }

                            var complaintFile = new ComplaintFile
                            {
                                FileName = fileName,
                                FilePath = "/files/" + fileName,
                                ComplaintId = complaintVM.Complaint.Id
                            };

                            await _mediator.Send(new CreateFileCommand(complaintFile));
                            await _mediator.Send(new SaveFileCommand());
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

        #region API CALLS
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

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return Json(new { success = false, message = "Invalid ID" });
            }

            Complaint complaintToBeDeleted = await _mediator.Send<Complaint>(new GetComplaintQuery(id.Value));

            if (complaintToBeDeleted == null)
            {
                return Json(new { success = false, message = "Complaint not found" });
            }

            List<ComplaintFile> relatedFiles = (await _mediator.Send<IEnumerable<ComplaintFile>>(new GetAllFilesQuery()))
                .Where(cf => cf.ComplaintId == id).ToList();

            foreach (var file in relatedFiles)
            {
                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, file.FilePath.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);/*
                        await _mediator.Send(new DeleteFileCommand(file));
                        await _mediator.Send(new SaveFileCommand());*/
                    }
                }


                await _mediator.Send(new DeleteFileCommand(file));
                await _mediator.Send(new SaveFileCommand());
            }

            await _mediator.Send(new DeleteComplaintCommand(complaintToBeDeleted));
            await _mediator.Send(new SaveFileCommand());

            return Json(new { success = true, message = "Complaint and related files deleted" });
        }


        public async Task<IActionResult> RemoveFile(Guid? id)
        {
            if (id == Guid.Empty)
            {
                TempData["success"] = "Invalid ID";
                return RedirectToAction("Upsert");
            }

            ComplaintFile fileToBeDeleted = await _mediator.Send<ComplaintFile>(new GetFileQuery(id.Value, "Complaint"));

            if (fileToBeDeleted == null)
            {
                TempData["success"] = "File not found";
                return RedirectToAction("Upsert");
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var oldImagePath = Path.Combine(wwwRootPath, fileToBeDeleted.FilePath.TrimStart('/'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
                await _mediator.Send(new DeleteFileCommand(fileToBeDeleted));
                await _mediator.Send(new SaveFileCommand());
            }

            TempData["success"] = "File deleted successfully";
            return RedirectToAction("Upsert", new { id = fileToBeDeleted.ComplaintId });
        }


        #endregion

    }
}
