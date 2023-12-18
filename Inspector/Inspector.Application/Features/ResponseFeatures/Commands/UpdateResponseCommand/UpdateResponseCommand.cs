using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ResponseFeatures.Commands.UpdateResponseCommand
{
	public record UpdateResponseCommand(Response response) : IRequest<Response> { }
}
