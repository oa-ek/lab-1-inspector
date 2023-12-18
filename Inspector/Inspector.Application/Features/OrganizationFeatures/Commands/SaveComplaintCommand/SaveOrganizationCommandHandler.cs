using AutoMapper;
using Inspector.Application.Features.OrganizationFeatures.Commands.SaveOrganizationCommand;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Commands.SaveComplaintCommand
{
	public class SaveOrganizationCommandHandler : IRequestHandler<SaveOrganizationCommand, Unit>
	{
		private readonly IOrganizationRepository _organizationRepository;
		public SaveOrganizationCommandHandler(IOrganizationRepository organizationRepository)
		{
			_organizationRepository = organizationRepository;
		}

		public async Task<Unit> Handle(SaveOrganizationCommand request, CancellationToken cancellationToken)
		{
			await _organizationRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
