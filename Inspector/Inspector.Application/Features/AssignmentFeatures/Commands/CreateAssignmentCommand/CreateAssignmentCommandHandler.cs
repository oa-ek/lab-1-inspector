using Inspector.Application.Repositories;
using MediatR;

namespace Inspector.Application.Features.AssignmentFeatures.Commands.CreateAssignmentCommand
{
	public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, Unit>
	{
		private readonly IAssignmentRepository _assignmentRepository;
		public CreateAssignmentCommandHandler(IAssignmentRepository assignmentRepository)
		{
			_assignmentRepository = assignmentRepository;
		}

		public async Task<Unit> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
		{
			await _assignmentRepository.CreateAsync(request.assignment);
			return Unit.Value; 
		}
	}
}
