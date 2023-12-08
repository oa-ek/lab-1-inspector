using MediatR;

namespace Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery
{
    public record GetAllOrganizationQuery(string? includeProperties = null) : IRequest<IEnumerable<OrganizationReadShortDto>> { }
}
