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
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Complaint> ApplicationUsers { get; set; }
    }
}
