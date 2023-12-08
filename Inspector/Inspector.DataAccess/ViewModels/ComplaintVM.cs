﻿using Inspector.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Models.ViewModels
{
	public class ComplaintVM
	{
		public Complaint Complaint { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> OrganizationList { get; set; }
	}
}