using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.UserFeatures.Commands.UpdateUSerRoleCommand
{
	public record UpdateUserRoleCommand(ApplicationUser user, string role) : IRequest<Unit> { }
}
