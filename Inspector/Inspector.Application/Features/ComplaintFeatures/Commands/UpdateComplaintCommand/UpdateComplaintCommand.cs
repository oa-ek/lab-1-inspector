using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.UpdateComplaintCommand
{
	public record UpdateComplaintCommand(Complaint complaint) : IRequest<Complaint> { }
}
