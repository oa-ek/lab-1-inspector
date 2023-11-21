using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Models
{
	public class Employment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey(nameof(User))]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		[ForeignKey(nameof(Organization))]
		public int? OrganizationId { get; set; }
		public Organization Organization { get; set; }
	}
}
