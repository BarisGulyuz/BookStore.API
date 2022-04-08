using BookStore.Bussiness.Abstract;
using BookStore.Entities.BasketEntities;
using BookStore.Entities.DTOs.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Book.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Member")]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public BasketsController(IBasketService basketService, IOrderService orderService)
        {
            _basketService = basketService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketItems(string id)
        {
            var items = await _basketService.GetBasketAsync(id);
            return Ok(items ?? new Basket(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(Basket basket)
        {
            if (basket.Id == null) basket.Id = Guid.NewGuid().ToString();
            var myBasket = await _basketService.UpdateBasketAsync(basket);
            return Ok(myBasket);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            await _basketService.DeleteBasketAsync(id);
            return NoContent();
        }


        [HttpPost("checkout/{basketId}")]
        public async Task<IActionResult> Checkout(OrderCreateDto orderCreateDto, string basketId)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _orderService.AddWithOrderLinesAsync(orderCreateDto, basketId, userId);
            if (result.IsSuccess) return Created("", result);
            return BadRequest(result);
        }
    }
}
