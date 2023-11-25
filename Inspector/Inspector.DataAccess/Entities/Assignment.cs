using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.IO.Compression;
using Inspector.Domain.Common;

namespace Inspector.Domain.Entities
{
    public class Assignment : BaseEntity
    {
        /*public Assignment()
        {
            CreatedDate = DateTime.Now;
        }*/

        public string? UserGiveId { get; set; }
        public string UserTakeId { get; set; }
        public Guid ComplaintId { get; set; }

        //чи треба це якщо воно у нас в байс є
        //public DateTime CreatedDate { get; set; }

        [ForeignKey("UserGiveId")]
        [ValidateNever]
        public ApplicationUser UserGive { get; set; }

        [ForeignKey("UserTakeId")]
        [ValidateNever]
        public ApplicationUser UserTake { get; set; }

        [ForeignKey("ComplaintId")]
        [ValidateNever]
        public Complaint Complaint { get; set; }
    }

}
