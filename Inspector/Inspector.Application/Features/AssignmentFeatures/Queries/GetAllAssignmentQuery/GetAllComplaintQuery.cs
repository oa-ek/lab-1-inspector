using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.GetAllAssignmentQuery
{
    public record GetAllAssignmentQuery(string? includeProperties = null) : IRequest<IEnumerable<Assignment>> { }
}
