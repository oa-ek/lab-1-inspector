using AutoMapper;
using Inspector.Application.Features.FileFeatures.Queries.GetAllFilesQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ResponseFeatures.Queries.GetAllResponseQuery
{
	public class GetAllResponseQueryHandler : IRequestHandler<GetAllResponseQuery, IEnumerable<Response>>
	{
		private readonly IResponseRepository _responseRepository;
		private readonly IMapper _mapper;
		public GetAllResponseQueryHandler(IResponseRepository responseRepository, IMapper mapper)
		{
			_mapper = mapper;
			_responseRepository = responseRepository;
		}

		public async Task<IEnumerable<Response>> Handle(GetAllResponseQuery request, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;
			return _mapper.Map<IEnumerable<Response>, IEnumerable<Response>>(await _responseRepository.GetAllAsync());
		}
	}
}
