using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery
{
    public class GetAllOrganizationQueryHandler : IRequestHandler<GetAllOrganizationQuery, IEnumerable<OrganizationReadShortDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public GetAllOrganizationQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _mapper = mapper;
			_organizationRepository = organizationRepository;
        }

        public async Task<IEnumerable<OrganizationReadShortDto>> Handle(GetAllOrganizationQuery request, CancellationToken cancellationToken)
        {  
            await Task.CompletedTask;
            return _mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationReadShortDto>>(await _organizationRepository.GetAllAsync(request.includeProperties));
        }
    }
}
