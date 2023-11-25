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
    public class ComplaintRepository : IComplaintRepository
    {
        protected readonly ApplicationDbContext Context;

        public ComplaintRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task CreateAsync(Complaint entity)
        {
            await Context.AddAsync(entity);
        }

        public async Task UpdateAsync(Complaint entity)
        {
            Context.Update(entity);
        }

        public async Task DeleteAsync(Complaint entity)
        {
            entity.CreateDate = DateTime.UtcNow;
            Context.Update(entity);
        }

        public async Task<Complaint> GetAsync (Guid id)
        {
            return await Context.Set<Complaint>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Complaint>> GetAllAsync() 
        {
            return await Context.Set<Complaint>().ToListAsync();
        }
        
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

		public Task<IEnumerable<Complaint>> FindComplaintPartAsync(string text)
		{
			throw new NotImplementedException();
		}
	}
}
