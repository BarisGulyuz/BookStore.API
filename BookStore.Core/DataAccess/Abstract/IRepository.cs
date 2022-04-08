using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        //Task<List<T>> SearchAsync(List<Expression<Func<T, bool>>> filters, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity); 
        Task Update(T entity);
        Task DeleteAsync(T entity);
        Task HardDelete(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
    }
}
