using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.FileFeatures.Queries.SaveComplaintQuery
{
	public class SaveComplaintQueryHandler : IRequestHandler<SaveComplaintQuery, Unit>
	{
		private readonly IComplaintRepository _complaintRepository;
		public SaveComplaintQueryHandler(IComplaintRepository complaintRepository)
		{
			_complaintRepository = complaintRepository;
		}

		public async Task<Unit> Handle(SaveComplaintQuery request, CancellationToken cancellationToken)
		{
			await _complaintRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
