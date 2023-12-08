using MediatR;

namespace Inspector.Application.Features.UserFeatures.Commands.SaveUserCommand
{
	public record SaveUserCommand() : IRequest<Unit> { }
}
