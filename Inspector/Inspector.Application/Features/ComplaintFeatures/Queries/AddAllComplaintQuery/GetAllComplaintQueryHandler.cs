using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery
{
    public class GetAllComplaintQueryHandler : IRequestHandler<GetAllComplaintQuery, IEnumerable<ComplaintReadShortDto>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;
        public GetAllComplaintQueryHandler(IComplaintRepository complaintRepository, IMapper mapper)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
        }

        public async Task<IEnumerable<ComplaintReadShortDto>> Handle(GetAllComplaintQuery request, CancellationToken cancellationToken)
        {  
            await Task.CompletedTask;
            return _mapper.Map<IEnumerable<Complaint>, IEnumerable<ComplaintReadShortDto>>(await _complaintRepository.GetAllAsync(request.includeProperties));
        }
    }
}
