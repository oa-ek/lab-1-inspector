using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery
{
    public record GetAllComplaintQuery(string? includeProperties = null) : IRequest<IEnumerable<Complaint>> { }
}
