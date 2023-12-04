using AutoMapper;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddComplaintQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.CreateResponseQuery
{
	public class CreateResponseQueryHandler : IRequestHandler<CreateResponseQuery, Unit>
	{
		private readonly IResponseRepository _responseRepository;
		public CreateResponseQueryHandler(IResponseRepository responseRepository)
		{
            _responseRepository = responseRepository;
		}

		public async Task<Unit> Handle(CreateResponseQuery request, CancellationToken cancellationToken)
		{
			await _responseRepository.CreateAsync(request.response);
			return Unit.Value; 
		}
	}
}
