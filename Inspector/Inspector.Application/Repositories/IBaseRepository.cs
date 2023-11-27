using Inspector.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Repositories
{
    public interface IBaseRepository<T> where T: class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Guid id, string? includeProperties = null);
        Task<List<T>> GetAllAsync(string? includeProperties = null); 
        Task SaveAsync();
    }
}
