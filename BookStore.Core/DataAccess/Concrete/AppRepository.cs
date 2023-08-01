using BookStore.Core.DataAccess.Abstract;
using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Core.DataAccess.Concrete
{
    public class AppRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _context;

        public AppRepository(DbContext context)
        {
            _context = context;
        }
        DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity, bool autoSave = false)
        {
            await Table.AddAsync(entity);
            if (autoSave)
                await SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity, bool autoSave = false)
        {
            Table.Update(entity);
            if (autoSave)
                await SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity, bool autoSave = false)
        {
            entity.Status = false;
            await UpdateAsync(entity, autoSave);
        }
        public async Task HardDelete(T entity, bool autoSave = false)
        {
            Table.Remove(entity);
            if (autoSave)
                await SaveChangesAsync();
        }
        public async Task HardDelete(int entityId, bool autoSave = false)
        {
            T entity = new()
            {
                Id = entityId
            };

            var targetRow = Table.Attach(entity);
            targetRow.State = EntityState.Deleted;

            if (autoSave)
                await SaveChangesAsync();
            //db exception fırlatabilir 
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool withAsNoTracking = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (withAsNoTracking) query = query.AsNoTracking();

            if (filter != null) query = query.Where(filter);

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

            if (filter != null) query = query.Where(filter);

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.SingleOrDefaultAsync();
        }
        public IQueryable<T> GetQueryable(bool withAsNoTracking = false)
                                         => withAsNoTracking ? Table.AsNoTracking().AsQueryable() : Table.AsQueryable();
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter) => await Table.AnyAsync(filter);
        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null) => await Table.CountAsync(filter);
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
