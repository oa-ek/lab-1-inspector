using AutoMapper;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddComplaintQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.CreateComplaintQuery
{
	public class CreateComplaintQueryHandler : IRequestHandler<CreateComplaintQuery, Complaint>
	{
		private readonly IComplaintRepository _complaintRepository;
		public CreateComplaintQueryHandler(IComplaintRepository complaintRepository)
		{
			_complaintRepository = complaintRepository;
		}

		public async Task<Complaint> Handle(CreateComplaintQuery request, CancellationToken cancellationToken)
		{
			await _complaintRepository.CreateAsync(request.complaint);
			return request.complaint; 
		}
	}
}
