using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery
{
    public record GetAllComplaintQuery(string? includeProperties = null) : IRequest<IEnumerable<Complaint>> { }
}
