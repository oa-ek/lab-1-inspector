using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Models
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; } // Поле Name з типом varchar
        public string Description { get; set; } 
        public ICollection<Complaint> Complaints { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Complaint> ApplicationUsers { get; set; }
    }
}
