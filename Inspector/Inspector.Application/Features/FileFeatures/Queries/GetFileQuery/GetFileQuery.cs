using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.FileFeatures.Queries.GetFileQuery
{
	public record GetFileQuery(Guid id, string? includeProperties = null) : IRequest<ComplaintFile> { }
}
