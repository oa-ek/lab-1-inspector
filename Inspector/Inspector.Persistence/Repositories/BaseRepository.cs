using Inspector.Application.Repositories;
using Inspector.Domain.Common;
using Inspector.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
	{
        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await Context.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            entity.CreateDate = DateTime.UtcNow;
            Context.Update(entity);
        }

		public async Task<T> GetAsync(Guid id, string? includeProperties = null)
		{
			var query = Context.Set<T>().AsQueryable();

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}

			return await query.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<T>> GetAllAsync(string? includeProperties = null) 
        {
			IQueryable<T> query = Context.Set<T>();
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
    }
}
