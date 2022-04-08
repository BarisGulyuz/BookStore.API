using BookStore.Core.Results;
using BookStore.Entities;
using BookStore.Entities.DTOs.OrderLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IOrderLineService
    {
        Task<DataResult<List<OrderLineGetDto>>> GetOrderLineByOrderIdAsync(int orderId);

        Task AddOrderLinesAsync(List<OrderLine> orders);
    }
}
