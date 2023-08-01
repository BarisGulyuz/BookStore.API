using BookStore.Core.Results;
using BookStore.Entities.DTOs.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IOrderService
    {
        Task<DataResult<List<OrderGetDto>>> GetOrdersAsync(int shipmentStatus, bool onlyActives = true);
        Task<Result> AddOrderAsync(OrderCreateDto orderCreateDto, string basketId, int userId);
        Task<Result> DeleteAsync(int id);
    }
}
