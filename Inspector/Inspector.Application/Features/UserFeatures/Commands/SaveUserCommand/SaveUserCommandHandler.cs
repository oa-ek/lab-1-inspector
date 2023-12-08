using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.UserFeatures.Commands.SaveUserCommand
{
	public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, Unit>
	{
		private readonly IUserRepository _userRepository;
		public SaveUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<Unit> Handle(SaveUserCommand request, CancellationToken cancellationToken)
		{
			await _userRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
