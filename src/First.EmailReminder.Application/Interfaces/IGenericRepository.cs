using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.EmailReminder.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}