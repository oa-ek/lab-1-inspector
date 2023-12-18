using MediatR;

namespace Inspector.Application.Features.OrganizationFeatures.Commands.SaveOrganizationCommand
{
	public record SaveOrganizationCommand() : IRequest<Unit> { }
}
