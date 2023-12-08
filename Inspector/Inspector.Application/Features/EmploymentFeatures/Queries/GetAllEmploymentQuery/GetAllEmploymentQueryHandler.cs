using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.EmploymentFeatures.Queries.CreateEmploymentQuery
{
    public class GetAllEmploymentQueryHandler : IRequestHandler<GetAllEmploymentQuery, IEnumerable<Employment>>
    {
        private readonly IEmploymentRepository _employmentRepository;
        private readonly IMapper _mapper;
        public GetAllEmploymentQueryHandler(IEmploymentRepository employmentRepository, IMapper mapper)
        {
            _mapper = mapper;
			_employmentRepository = employmentRepository;
        }

        public async Task<IEnumerable<Employment>> Handle(GetAllEmploymentQuery request, CancellationToken cancellationToken)
        {  
            await Task.CompletedTask;
            return _mapper.Map<IEnumerable<Employment>, IEnumerable<Employment>>(await _employmentRepository.GetAllAsync(request.includeProperties));
        }
    }
}
