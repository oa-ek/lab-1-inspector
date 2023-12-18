using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.EmploymentFeatures.Commands.SaveEmploymentCommand
{
	public class SaveEmploymentCommandHandler : IRequestHandler<SaveEmploymentCommand, Unit>
	{
		private readonly IEmploymentRepository _employmentRepository;
		public SaveEmploymentCommandHandler(IEmploymentRepository employmentRepository)
		{
			_employmentRepository = employmentRepository;
		}

		public async Task<Unit> Handle(SaveEmploymentCommand request, CancellationToken cancellationToken)
		{
			await _employmentRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
