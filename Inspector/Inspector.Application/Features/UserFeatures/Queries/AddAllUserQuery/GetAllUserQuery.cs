using Inspector.Application.Features.OrganizationFeatures.Queries.AddAllOrganizationQuery;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.UserFeatures.Queries.AddAllUserQuery
{
    public record GetAllUserQuery(string? includeProperties = null) : IRequest<IEnumerable<UserReadShortDto>> { }
}
