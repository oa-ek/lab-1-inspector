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

namespace Inspector.Application.Features.ComplaintFeatures.Queries.CreateEmploymentQuery
{
	public class CreateEmploymentQueryyHandler : IRequestHandler<CreateEmploymentQuery, Unit>
	{
		private readonly IEmploymentRepository _employmentRepository;
		public CreateEmploymentQueryyHandler(IEmploymentRepository employmentRepository)
		{
			_employmentRepository = employmentRepository;
		}

		public async Task<Unit> Handle(CreateEmploymentQuery request, CancellationToken cancellationToken)
		{
			await _employmentRepository.CreateAsync(request.employment);
			return Unit.Value; 
		}
	}
}
