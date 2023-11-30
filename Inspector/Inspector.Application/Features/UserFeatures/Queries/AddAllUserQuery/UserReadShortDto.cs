using Inspector.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.UserFeatures.Queries.AddAllUserQuery
{
    public class UserReadShortDto : IdentityUser
	{
        public int Id { get; set; }
        public string FullName { get; set; }
		public Guid OrganizationId { get; set; }
		public Organization Organization { get; set; }

		//phone number
	}
}
