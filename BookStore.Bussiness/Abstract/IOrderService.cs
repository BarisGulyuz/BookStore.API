using BookStore.Core.Enums;
using BookStore.Core.Results;
using BookStore.Entities.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IOrderService
    {
        Task<DataResult<List<OrderGetDto>>> GetOrdersAsync(int shipmentStatus);
        Task<Result> AddWithOrderLinesAsync(OrderCreateDto orderCreateDto, string basketId, int userId);
        Task<Result> DeleteAsync(int id);

        //Task<Result> UpdateAsync(OrderUpdateDto authorUpdateDto);
    }
}
