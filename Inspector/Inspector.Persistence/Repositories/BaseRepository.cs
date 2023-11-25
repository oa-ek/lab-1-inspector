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

        public async Task<T> GetAsync (Guid id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAllAsync() 
        {
            return await Context.Set<T>().ToListAsync();
        }
        
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
