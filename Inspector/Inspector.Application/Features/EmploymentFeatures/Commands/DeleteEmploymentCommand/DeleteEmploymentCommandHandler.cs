using Inspector.Application.Features.EmploymentFeatures.Commands.DeleteEmploymentCommand;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.EmploymentFeatures.Commands.DeleteEmploymentCommand
{
	public class DeleteEmploymentCommandHandler : IRequestHandler<DeleteEmploymentCommand, Employment>
	{
		private readonly IEmploymentRepository _employmentRepository;
		public DeleteEmploymentCommandHandler(IEmploymentRepository employmentRepository)
		{
			_employmentRepository = employmentRepository;
		}

		public async Task<Employment> Handle(DeleteEmploymentCommand request, CancellationToken cancellationToken)
		{
			await _employmentRepository.DeleteAsync(request.employee);
			return request.employee; 
		}
	}
}
