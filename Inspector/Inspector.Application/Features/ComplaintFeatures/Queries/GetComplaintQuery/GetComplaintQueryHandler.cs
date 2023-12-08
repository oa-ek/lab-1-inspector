using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.GetComplaintQuery
{
	public class GetComplaintQueryHandler : IRequestHandler<GetComplaintQuery, Complaint>
	{
		private readonly IComplaintRepository _complaintRepository;
		private readonly IMapper _mapper;
		public GetComplaintQueryHandler(IComplaintRepository complaintRepository, IMapper mapper)
		{
			_mapper = mapper;
			_complaintRepository = complaintRepository;
		}

		public async Task<Complaint> Handle(GetComplaintQuery request, CancellationToken cancellationToken)
		{
			return await Task.FromResult(_mapper.Map<Complaint, Complaint>(await _complaintRepository.GetAsync(request.id, request.includeProperties)));
		}

	}
}
