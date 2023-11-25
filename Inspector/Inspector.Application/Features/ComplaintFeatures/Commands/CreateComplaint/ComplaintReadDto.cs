using Inspector.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.CreateComplaint
{
    public class ComplaintReadDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Description { get; set; }
        //[NotMapped]
        public ICollection<ComplaintFile>? ComplaintFiles { get; set; }
        public string Status { get; set; }
        public int? ResponceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsArchive { get; set; }

        //public UserReadShortDto? Owner { get; set; }
    }
}
