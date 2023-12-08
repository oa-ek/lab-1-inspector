using AutoMapper;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.GetUserQuery
{
	public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationUser>
	{
		private readonly IUserRepository _userRepository;
		public GetUserQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<ApplicationUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			return await _userRepository.GetAsync(Guid.Parse(request.id), request.includeProperties);
		}

	}
}
