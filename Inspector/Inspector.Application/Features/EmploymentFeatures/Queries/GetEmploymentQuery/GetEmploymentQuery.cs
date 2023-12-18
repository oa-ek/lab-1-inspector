using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.EmploymentFeatures.Queries.GetEmploymentQuery
{
	public record GetEmploymentQuery(Guid id, string? includeProperties = null) : IRequest<Employment> { }
}
