using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.CommandFeatures.Commands.SaveResponseCommand
{
	public class SaveResponseCommandHandler : IRequestHandler<SaveResponseCommand, Unit>
	{
        private readonly IResponseRepository _responseRepository;
        public SaveResponseCommandHandler(IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }

        public async Task<Unit> Handle(SaveResponseCommand request, CancellationToken cancellationToken)
		{
			await _responseRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
