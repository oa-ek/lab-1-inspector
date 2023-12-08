using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery
{
	public record GetComplaintQuery(Guid id, string? includeProperties = null) : IRequest<Complaint> { }
}
