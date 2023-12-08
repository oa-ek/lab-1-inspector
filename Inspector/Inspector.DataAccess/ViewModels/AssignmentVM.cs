using Inspector.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Models.ViewModels
{
	public class AssignmentVM
	{
		public AssignmentVM()
		{
			Assignment = new Assignment();

		}
		public Assignment Assignment { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> UserList { get; set; }
	}
}
