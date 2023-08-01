using BookStore.Bussiness.Abstract;
using BookStore.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Book.Store.Api.Controllers
{

    public class OrdersController : BaseAdminController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int shipmentStatus = (int)ShipmentStatusEnum.All)
        {
            var result = await _orderService.GetOrdersAsync(shipmentStatus);
            if (result.IsSuccess) return Ok(result.Data);
            return BadRequest(result);
        }

    }
}
