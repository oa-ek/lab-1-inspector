using MediatR;

namespace Inspector.Application.Features.UserFeatures.Queries.GetAllUserQuery
{
    public record GetAllUserQuery(string? includeProperties = null) : IRequest<IEnumerable<UserReadShortDto>> { }
}
