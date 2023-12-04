using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Inspector.Domain.Common;

namespace Inspector.Domain.Entities
{
    public class Response : BaseEntity
    {
        public string Description { get; set; }
        public string? File { get; set; }
        [ForeignKey("ComplaintId")]
        public Guid ComplaintId { get; set; }
        public string? UserTakeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
