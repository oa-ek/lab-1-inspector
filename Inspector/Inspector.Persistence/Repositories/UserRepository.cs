using Inspector.Application.Repositories;
using Inspector.Domain.Common;
using Inspector.Domain.Data;
using Inspector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		public Task CreateAsync(ApplicationUser entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(ApplicationUser entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<ApplicationUser>> GetAllAsync(string? includeProperties = null)
		{
			throw new NotImplementedException();
		}
		public Task<ApplicationUser> GetAsync(Guid id, string? includeProperties = null)
		{
			throw new NotImplementedException();
		}

		public Task SaveAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(ApplicationUser entity)
		{
			throw new NotImplementedException();
		}
	}
}
