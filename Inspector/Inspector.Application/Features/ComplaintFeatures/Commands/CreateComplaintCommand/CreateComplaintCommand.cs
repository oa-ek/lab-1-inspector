using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.CreateComplaintCommand
{
	public record CreateComplaintCommand(Complaint complaint) : IRequest<Complaint> { }
}
