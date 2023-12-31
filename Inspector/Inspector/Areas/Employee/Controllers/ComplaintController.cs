﻿using Inspector.DataAccess.Data;
using Inspector.DataAccess.Repository;
using Inspector.DataAccess.Repository.IRepository;
using Inspector.Models;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Security.Claims;

namespace InspectorWeb.Areas.Employee.Controllers
{
	[Area("Employee")]
	public class ComplaintController : Controller
    {
        private readonly IAssignmentRepository _assignmentRepo;
        private readonly IComplaintRepository _complaintRepo;
        private readonly IOrganizationRepository _organizationRepo;

        public ComplaintController(
            IComplaintRepository complaintRepo,
            IAssignmentRepository assignmentRepo,
            IOrganizationRepository organizationRepo)
        {
            _complaintRepo = complaintRepo;
            _assignmentRepo = assignmentRepo;
            _organizationRepo = organizationRepo;
        }


        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            List<Assignment> assignments = _assignmentRepo.GetAll().ToList();
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();

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
        public IActionResult Info(int? ComplaintId)
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

            complaintVC.Complaint = _complaintRepo.Get(u => u.Id == ComplaintId);
            return View(complaintVC);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            List<Assignment> assignments = _assignmentRepo.GetAll().ToList();
            List<Complaint> complaintList = _complaintRepo.GetAll(includeProperties: "Organization,User").ToList();

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
