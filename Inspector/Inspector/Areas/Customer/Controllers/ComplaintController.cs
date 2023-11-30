using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Inspector.Domain.Entities;
using MediatR;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;

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
            /*string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Отримати ID поточного користувача

            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();

            if (!string.IsNullOrEmpty(userId))
            {
                // Створіть новий список для зберігання скарг, які відповідають умові
                List<Complaint> filteredComplaints = new List<Complaint>();

                foreach (var item in complaintList)
                {
                    // Отримайте скарги, які відповідають умові
                    if (item.UserId == userId)
                    {
                        filteredComplaints.Add(item);
                    }
                }

                // Оновіть complaintList, щоб показувати тільки відфільтровані скарги
                complaintList = filteredComplaints;
                return View(complaintList);
            }

            return View(complaintList);*/

            var complaints = await _mediator.Send<IEnumerable<OrganizationReadShortDto>>(new GetAllComplaintQuery());
            return View(complaints);

        }

        /*public IActionResult Upsert(int? id)
        {
            ComplaintVM complaintVC = new()
            {
                OrganizationList = _organizationRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Complaint = new Complaint()
            };

            if (id == null || id == 0)
            {
                //create
                return View(complaintVC);
            }
            else
            {
                //update
                complaintVC.Complaint = _complaintRepo.Get(u => u.Id == id);
                return View(complaintVC);
            }
        }


        //зробити так, щоб бачити які файли вже є на цю скаргу при редагуванні
        //ізараз якщо я маю файли на скаргу, при оновлені вони видаляться, то зробити так щоб користувач то вручну робив і може якийсь видаляв а якийсь ні
        [HttpPost]
        public IActionResult Upsert(ComplaintVM complaintVM, List<IFormFile>? files)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (complaintVM.Complaint.Id == 0)
                {
                    complaintVM.Complaint.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _complaintRepo.Add(complaintVM.Complaint);
                    TempData["success"] = "Complaint created successfully";
                }
                else
                {
                    complaintVM.Complaint.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _complaintRepo.Update(complaintVM.Complaint);

                    //видалення файлів які були збережені на цю скаргу раніше
                    var complaintFiles = _complaintFileRepo.GetAll().Where(cf => cf.ComplaintId == complaintVM.Complaint.Id).ToList();

                    foreach (var compFile in complaintFiles)
                    {
                        if (!string.IsNullOrEmpty(compFile.FilePath))
                        {
                            var oldImagePath = Path.Combine(wwwRootPath, compFile.FilePath.TrimStart('/'));

                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                                _complaintFileRepo.Remove(compFile);
                                _complaintFileRepo.Save();
                            }
                        }
                    }

                    TempData["success"] = "Complaint update successfully";
                }

                _complaintRepo.Save();

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

							_complaintFileRepo.Add(complaintFile);
                            _complaintFileRepo.Save();
                        }
					}
				}

                return RedirectToAction("Index");
            }
            else
            {
                complaintVM.OrganizationList = _organizationRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(complaintVM);
            }
        }*/


        #region API CALLS

        //[HttpGet]
        /*public IActionResult GetAll()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Отримати ID поточного користувача
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();

            if (!string.IsNullOrEmpty(userId))
            {
                // Створіть новий список для зберігання скарг, які відповідають умові
                List<Complaint> filteredComplaints = new List<Complaint>();

                foreach (var item in complaintList)
                {
                    // Отримайте скарги, які відповідають умові
                    if (item.UserId == userId)
                    {
                        filteredComplaints.Add(item);
                    }
                }

                // Оновіть complaintList, щоб показувати тільки відфільтровані скарги
                complaintList = filteredComplaints;
            }

            //return View(complaintList);
            //List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();
            return Json(new { data = complaintList });

        }


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
