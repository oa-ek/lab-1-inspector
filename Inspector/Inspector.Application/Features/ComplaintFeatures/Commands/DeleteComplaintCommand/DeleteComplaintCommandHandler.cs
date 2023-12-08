using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.DeleteComplaintCommand
{
	public class DeleteComplaintCommandHandler : IRequestHandler<DeleteComplaintCommand, Complaint>
	{
		private readonly IComplaintRepository _complaintRepository;
		public DeleteComplaintCommandHandler(IComplaintRepository complaintRepository)
		{
			_complaintRepository = complaintRepository;
		}

		public async Task<Complaint> Handle(DeleteComplaintCommand request, CancellationToken cancellationToken)
		{
			await _complaintRepository.DeleteAsync(request.complaint);
			return request.complaint; 
		}
	}
}
