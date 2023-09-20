using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Models
{
    public class Complaint
    {
        public Complaint()
        {
            Status = "sent"; 
            ResponceId = null;
            File = null;
            CreatedDate = DateTime.Now;
            UserId = -1;
            IsArchive = false;
		}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public string UserName { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
		[ValidateNever]
		public User User { get; set; }

        [ForeignKey("OrganizationId")]
		public int OrganizationId { get; set; }
		[ValidateNever]
		public Organization Organization { get; set; }
		[MaxLength(300)]
		public string Description { get; set; } 
        public string? File { get; set; }
        public string Status { get; set; }

        [ForeignKey("ResponceId")]
        public int? ResponceId { get; set; }
        public DateTime CreatedDate { get; set; }   
        
        public bool IsArchive { get; set; }
    }
}
