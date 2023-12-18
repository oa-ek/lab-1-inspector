using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ResponseFeatures.Queries.GetAllResponseQuery
{
	public record GetAllResponseQuery() : IRequest<IEnumerable<Response>> { }
}
