using AutoMapper;
using Inspector.Application.Features.OrganizationFeatures.Queries.AddAllOrganizationQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.UserFeatures.Queries.AddAllUserQuery
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserReadShortDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
			_userRepository = userRepository;
        }

        public async Task<IEnumerable<UserReadShortDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserReadShortDto>>(await _userRepository.GetAllAsync(request.includeProperties));
        }
    }
}
