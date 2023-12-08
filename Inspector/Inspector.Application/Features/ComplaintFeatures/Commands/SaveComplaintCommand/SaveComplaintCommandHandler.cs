using AutoMapper;
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
	public class SaveComplaintCommandHandler : IRequestHandler<SaveComplaintCommand, Unit>
	{
		private readonly IComplaintRepository _complaintRepository;
		public SaveComplaintCommandHandler(IComplaintRepository complaintRepository)
		{
			_complaintRepository = complaintRepository;
		}

		public async Task<Unit> Handle(SaveComplaintCommand request, CancellationToken cancellationToken)
		{
			await _complaintRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
