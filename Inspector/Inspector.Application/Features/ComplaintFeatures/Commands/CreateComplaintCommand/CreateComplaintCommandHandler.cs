using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.CreateComplaintCommand
{
	public class CreateComplaintCommandHandler : IRequestHandler<CreateComplaintCommand, Complaint>
	{
		private readonly IComplaintRepository _complaintRepository;
		public CreateComplaintCommandHandler(IComplaintRepository complaintRepository)
		{
			_complaintRepository = complaintRepository;
		}

		public async Task<Complaint> Handle(CreateComplaintCommand request, CancellationToken cancellationToken)
		{
			await _complaintRepository.CreateAsync(request.complaint);
			return request.complaint; 
		}
	}
}
