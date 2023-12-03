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

namespace Inspector.Application.Features.ComplaintFeatures.Queries.UpdateComplaintQuery
{
	public class UpdateComplaintQueryHandler : IRequestHandler<UpdateComplaintQuery, Complaint>
	{
		private readonly IComplaintRepository _complaintRepository;
		public UpdateComplaintQueryHandler(IComplaintRepository complaintRepository)
		{
			_complaintRepository = complaintRepository;
		}

		public async Task<Complaint> Handle(UpdateComplaintQuery request, CancellationToken cancellationToken)
		{
			await _complaintRepository.UpdateAsync(request.complaint);
			return request.complaint; 
		}
	}
}
