using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.SaveComplaintCommand
{
	public record SaveComplaintCommand() : IRequest<Unit> { }
}
