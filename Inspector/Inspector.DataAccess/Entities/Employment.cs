using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inspector.Domain.Common;

namespace Inspector.Domain.Entities
{
    public class Employment : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid? OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
