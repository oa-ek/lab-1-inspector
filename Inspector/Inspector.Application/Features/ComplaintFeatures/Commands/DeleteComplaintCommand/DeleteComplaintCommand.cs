using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.DeleteComplaintCommand
{
	public record DeleteComplaintCommand(Complaint complaint) : IRequest<Complaint> { }
}
