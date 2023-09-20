using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Inspector.Models
{
    public class Responce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }

		public string? File { get; set; }

		[ForeignKey("ComplaintId")]
        public int ComplaintId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
