using Inspector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.OrganizationFeatures.Queries.AddAllOrganizationQuery
{
	public class OrganizationReadShortDto
    {
        public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
