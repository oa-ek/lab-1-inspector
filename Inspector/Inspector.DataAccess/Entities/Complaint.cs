using Inspector.Domain.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Domain.Entities
{
    public class Complaint : BaseEntity
    {
        public Complaint()
        {
            Status = "created";
           /* Status = "sent";
            ResponceId = null;*/
            File = null;
            CreatedDate = DateTime.Now;/*
            UserId = "1";*/
            IsArchive = false;
        }

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }
        [ValidateNever]
        public Organization Organization { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        //
        public string? File { get; set; }
        public ICollection<ComplaintFile>? ComplaintFiles { get; set; }
        public string? Status { get; set; }

        [ForeignKey("ResponceId")]
        public Guid? ResponceId { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsArchive { get; set; }
    }
}
