using Inspector.Application.Repositories;
using Inspector.Domain.Common;
using Inspector.Domain.Data;
using Inspector.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
	public class UserRepository :  IUserRepository
	{
		protected readonly ApplicationDbContext Context;
		private readonly UserManager<IdentityUser> _userManager;
		public UserRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			Context = context;
			_userManager = userManager;
		}

		public async Task CreateAsync(ApplicationUser entity)
		{
			await Context.AddAsync(entity);
		}

		public async Task UpdateAsync(ApplicationUser entity)
		{
			Context.Update(entity);
		}

		public async Task DeleteAsync(ApplicationUser entity)
		{
			Context.Update(entity);
		}

		public async Task<ApplicationUser> GetAsync(Guid id, string? includeProperties = null)
		{
			var query = Context.Set<ApplicationUser>().AsQueryable();

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}

			return await query.FirstOrDefaultAsync(x => x.Id == id.ToString());
		}

		public async Task<List<ApplicationUser>> GetAllAsync(string? includeProperties = null)
		{
			IQueryable<ApplicationUser> query = Context.Set<ApplicationUser>();
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return await query.ToListAsync();
		}
		public async Task SaveAsync()
		{
			await Context.SaveChangesAsync();
		}

		public async Task UpdateUserRoleAsync(ApplicationUser entity, string role)
		{
			var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);

			if ((await _userManager.GetRolesAsync(user)).Any())
			{
				await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
			}

			if (role.Any())
			{
				await _userManager.AddToRolesAsync(user, new List<string> { role });
			}

			await Context.SaveChangesAsync();
		}

		public async Task<IEnumerable<string?>> GetRolesAsync()
		{
			return Context.Roles.Select(x => x.Name).ToList();
		}
	}
}
