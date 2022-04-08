using BookStore.Core.DataAccess.Abstract;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IOrderLineRepository : IRepository<OrderLine>
    {
        Task AddRangeAsync(List<OrderLine> orderLines);
    }
}
