using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.UserFeatures.Commands.UpdateUSerRoleCommand
{
	public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, Unit>
	{
		private readonly IUserRepository _userRepository;
		public UpdateUserRoleCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<Unit> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
		{
			await _userRepository.UpdateUserRoleAsync(request.user, request.role);
			return Unit.Value;
		}
	}
}
