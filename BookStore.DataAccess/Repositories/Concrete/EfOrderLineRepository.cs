using BookStore.Core.DataAccess.Concrete;
using BookStore.DataAccess.Contexts;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EfOrderLineRepository : AppRepository<OrderLine>, IOrderLineRepository
    {
        private readonly DbContext _context;
        public EfOrderLineRepository(BookStoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<OrderLine> orderLines)
        {
            await _context.Set<OrderLine>().AddRangeAsync(orderLines);
            await _context.SaveChangesAsync();
        }
    }
}
