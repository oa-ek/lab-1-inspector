using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.UserFeatures.Queries.GetAllUserQuery
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
