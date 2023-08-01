using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Core.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool withAsNoTracking = true, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetQueryable(bool withAsNoTracking = false);
        Task AddAsync(T entity, bool autoSave = false);
        Task UpdateAsync(T entity, bool autoSave = false);
        Task DeleteAsync(T entity, bool autoSave = false);
        Task HardDelete(T entity, bool autoSave = false);
        Task HardDelete(int entityId, bool autoSave = false);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
        Task<int> SaveChangesAsync();
    }
}
