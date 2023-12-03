using AutoMapper;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.AddComplaintQuery
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
