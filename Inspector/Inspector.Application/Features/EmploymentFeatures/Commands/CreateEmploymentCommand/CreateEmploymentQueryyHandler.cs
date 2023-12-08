using Inspector.Application.Repositories;
using MediatR;

namespace Inspector.Application.Features.EmploymentFeatures.Commands.CreateEmploymentCommand
{
	public class CreateEmploymentCommandHandler : IRequestHandler<CreateEmploymentCommand, Unit>
	{
		private readonly IEmploymentRepository _employmentRepository;
		public CreateEmploymentCommandHandler(IEmploymentRepository employmentRepository)
		{
			_employmentRepository = employmentRepository;
		}

		public async Task<Unit> Handle(CreateEmploymentCommand request, CancellationToken cancellationToken)
		{
			await _employmentRepository.CreateAsync(request.employment);
			return Unit.Value; 
		}
	}
}
