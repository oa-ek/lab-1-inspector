using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.GetAllComplaintQuery
{
    public class GetAllComplaintQueryHandler : IRequestHandler<GetAllComplaintQuery, IEnumerable<Complaint>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;
        public GetAllComplaintQueryHandler(IComplaintRepository complaintRepository, IMapper mapper)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
        }

        public async Task<IEnumerable<Complaint>> Handle(GetAllComplaintQuery request, CancellationToken cancellationToken)
        {  
            await Task.CompletedTask;
            return _mapper.Map<IEnumerable<Complaint>, IEnumerable<Complaint>>(await _complaintRepository.GetAllAsync(request.includeProperties));
        }
    }
}
