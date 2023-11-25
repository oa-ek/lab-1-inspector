using Inspector.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Domain.Entities
{
    public class ComplaintFile : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        [ForeignKey(nameof(Complaint))]
        public Guid ComplaintId { get; set; }
        public Complaint Complaint { get; set; }
    }

}
