using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.FileFeatures.Queries.SaveResponseQuery
{
	public class SaveResponseQueryHandler : IRequestHandler<SaveResponseQuery, Unit>
	{
        private readonly IResponseRepository _responseRepository;
        public SaveResponseQueryHandler(IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }

        public async Task<Unit> Handle(SaveResponseQuery request, CancellationToken cancellationToken)
		{
			await _responseRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
