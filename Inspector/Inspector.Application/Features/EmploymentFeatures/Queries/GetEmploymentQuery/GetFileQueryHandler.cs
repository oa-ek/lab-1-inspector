using AutoMapper;
using Inspector.Application.Features.EmploymentFeatures.Queries.GetEmploymentQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.EmploymentFeatures.Queries.GetEmploymentQuery
{
	public class GetEmploymentQueryHandler : IRequestHandler<GetEmploymentQuery, Employment>
	{
		private readonly IEmploymentRepository _employmentRepository;
		private readonly IMapper _mapper;
		public GetEmploymentQueryHandler(IEmploymentRepository employmentRepository, IMapper mapper)
		{
			_mapper = mapper;
            _employmentRepository = employmentRepository;
		}

		public async Task<Employment> Handle(GetEmploymentQuery request, CancellationToken cancellationToken)
		{
			return await Task.FromResult(_mapper.Map<Employment, Employment>(await _employmentRepository.GetAsync(request.id, request.includeProperties)));
		}

	}
}
