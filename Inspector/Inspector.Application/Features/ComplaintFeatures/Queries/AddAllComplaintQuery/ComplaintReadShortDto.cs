using Inspector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery
{
    public class ComplaintReadShortDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        //[NotMapped]
        public ICollection<ComplaintFile>? ComplaintFiles { get; set; }
        public string Status { get; set; }
        public int? ResponceId { get; set; }
    }
}
