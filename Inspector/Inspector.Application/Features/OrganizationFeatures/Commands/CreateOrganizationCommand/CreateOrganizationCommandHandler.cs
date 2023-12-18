using Inspector.Application.Features.OrganizationFeatures.Commands.CreateOrganizationCommand;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.OrganizationFeatures.Commands.CreateOrganizationCommand
{
	public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, Organization>
	{
		private readonly IOrganizationRepository _organizationRepository;
		public CreateOrganizationCommandHandler(IOrganizationRepository organizationRepository)
		{
			_organizationRepository = organizationRepository;
		}

		public async Task<Organization> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
		{
			await _organizationRepository.CreateAsync(request.org);
			return request.org; 
		}
	}
}
