using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.AddComplaintQuery
{
	public record GetComplaintQuery(Guid id, string? includeProperties = null) : IRequest<Complaint> { }
}
