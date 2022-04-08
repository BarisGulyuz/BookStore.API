using BookStore.Core.DataAccess.Abstract;
using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DataAccess.Concrete
{
    public class AppRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public AppRepository(DbContext context)
        {
            _context = context;
        }
        DbSet<T> Table => _context.Set<T>();
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await Table.AnyAsync(filter);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            return await Table.CountAsync(filter);
        }

        public async Task DeleteAsync(T entity)
        {
            entity.Status = false;
            await Update(entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (filter != null) { query = query.Where(filter); }
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (filter != null) { query = query.Where(filter); }
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task HardDelete(T entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
