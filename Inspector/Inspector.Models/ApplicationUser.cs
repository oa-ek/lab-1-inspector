using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Inspector.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.IO.Compression;

namespace Inspector.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }

        [ForeignKey("OrganizationId")]
        public int? OrganizationId { get; set; }
        [ValidateNever]
        public Organization Organization { get; set; }
		public ICollection<Complaint> Complaints { get; set; }
		[InverseProperty("UserGive")]
		public ICollection<Assignment> AssignmentsGiven { get; set; }

		[InverseProperty("UserTake")]
		public ICollection<Assignment> AssignmentsTaken { get; set; }
	}
}
