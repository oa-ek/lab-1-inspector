using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.AssignmentFeatures.Commands.SaveAssignmentCommand
{
	public class SaveEmploymentQueryHandler : IRequestHandler<SaveAssignmentCommand, Unit>
	{
		private readonly IAssignmentRepository _assignmentRepository;
		public SaveEmploymentQueryHandler(IAssignmentRepository assignmentRepository)
		{
			_assignmentRepository = assignmentRepository;
		}

		public async Task<Unit> Handle(SaveAssignmentCommand request, CancellationToken cancellationToken)
		{
			await _assignmentRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
