using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.FileFeatures.Queries.SaveEmploymentQuery
{
	public class SaveEmploymentQueryHandler : IRequestHandler<SaveEmploymentQuery, Unit>
	{
		private readonly IEmploymentRepository _employmentRepository;
		public SaveEmploymentQueryHandler(IEmploymentRepository employmentRepository)
		{
			_employmentRepository = employmentRepository;
		}

		public async Task<Unit> Handle(SaveEmploymentQuery request, CancellationToken cancellationToken)
		{
			await _employmentRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
