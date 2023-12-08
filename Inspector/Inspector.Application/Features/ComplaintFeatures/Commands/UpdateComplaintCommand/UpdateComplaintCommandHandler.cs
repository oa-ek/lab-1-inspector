using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.UpdateComplaintCommand
{
	public class UpdateComplaintCommandHandler : IRequestHandler<UpdateComplaintCommand, Complaint>
	{
		private readonly IComplaintRepository _complaintRepository;
		public UpdateComplaintCommandHandler(IComplaintRepository complaintRepository)
		{
			_complaintRepository = complaintRepository;
		}

		public async Task<Complaint> Handle(UpdateComplaintCommand request, CancellationToken cancellationToken)
		{
			await _complaintRepository.UpdateAsync(request.complaint);
			return request.complaint; 
		}
	}
}
