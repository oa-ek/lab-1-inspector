using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.OrganizationFeatures.Commands.CreateOrganizationCommand
{
	public record CreateOrganizationCommand(Organization org) : IRequest<Organization> { }
}
