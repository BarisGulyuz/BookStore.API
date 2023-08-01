using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Bussiness.Extensions;
using BookStore.Core.DataAccess.Abstract;
using BookStore.Core.Enums;
using BookStore.Core.Results;
using BookStore.Entities;
using BookStore.Entities.BasketEntities;
using BookStore.Entities.DTOs.Order;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class OrderManager : IOrderService
    {
        const int MAX_QUANTITY_PER_ITEM = 5;

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public OrderManager(IRepository<Order> orderRepository, IBasketService basketService, IMapper mapper, IRepository<Book> bookRepository)
        {
            _orderRepository = orderRepository;
            _basketService = basketService;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<Result> AddOrderAsync(OrderCreateDto orderCreateDto, string basketId, int userId)
        {
            Order order = _mapper.Map<Order>(orderCreateDto);
            order.UserId = userId;
            order.ShipmentStatus = (int)ShipmentStatusEnum.Waiting;
            order.Status = true;

            Basket basketResult = null;
            Result validationResult = await IsOrderValid(basketId, basketResult);
            if (validationResult.IsSuccess)
            {
                PreprareOrder(order, basketResult);
                await _orderRepository.AddAsync(order);

                Result updateResult = await UpdateBookQuantites(order);

                if (updateResult.IsSuccess)
                    await _orderRepository.SaveChangesAsync();
                else
                    return updateResult;
            }
            return Result.Success();
        }

        public async Task<DataResult<List<OrderGetDto>>> GetOrdersAsync(int shipmentStatus, bool onlyActives = true)
        {
            IQueryable<Order> orders = _orderRepository.GetQueryable(withAsNoTracking: true)
                                                      .Include(x => x.User)
                                                      .Include(x => x.OrderLines);

            orders = orders.WhereIf(x => x.ShipmentStatus == shipmentStatus, condition: shipmentStatus != (int)ShipmentStatusEnum.All);
            orders = orders.WhereIf(x => x.Status == true, condition: onlyActives);

            List<OrderGetDto> orderGetDtos = await _mapper.ProjectTo<OrderGetDto>(orders).ToListAsync();

            if (orderGetDtos.Count > 0)
                return DataResult<List<OrderGetDto>>.Success(orderGetDtos);

            return DataResult<List<OrderGetDto>>.Failure("There is no data for this query");
        }

        public async Task<Result> DeleteAsync(int id)
        {
            Order order = await _orderRepository.GetAsync(x => x.Id == id);
            if (order != null)
            {
                await _orderRepository.DeleteAsync(order, autoSave: true);
                return Result.Success();
            }
            return Result.Failure("There is no data for this query");

        }

        #region Private Methods

        private static void PreprareOrder(Order order, Basket basketResult)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            foreach (var basket in basketResult.BasketItems)
            {
                orderLines.Add(new OrderLine
                {
                    OrderId = order.Id,
                    BookName = basket.BookName,
                    Price = basket.Price,
                    Quantity = basket.Quantity,
                    Status = true
                });
            }
            order.OrderLines = orderLines;
        }
        private async Task<Result> UpdateBookQuantites(Order order)
        {
            Result result = new Result();
            foreach (var orderItem in order.OrderLines)
            {
                var targetBook = await _bookRepository.GetAsync(b => b.Id == orderItem.BookId);
                if (targetBook.TotalQuantity >= orderItem.Quantity)
                {
                    targetBook.TotalQuantity -= orderItem.Quantity;
                }
                else
                {
                    result.SetError($"We only have {targetBook.TotalQuantity} of the book {targetBook.Name} right now");
                    break;
                }
            }

            return result;
        }
        private async Task<Result> IsOrderValid(string basketId, Basket basket)
        {
            Result result = new Result();

            basket = await _basketService.GetBasketAsync(basketId);

            if (!(basket != null && basket.BasketItems.Count > 0))
                result.SetError($"There no basket item for {basketId}");
            else
            {
                bool isItemsCountsValid = basket.BasketItems.Any(x => x.Quantity > MAX_QUANTITY_PER_ITEM);
                if (!isItemsCountsValid)
                    result.SetError($"Item quantities cannot be bigger than {MAX_QUANTITY_PER_ITEM}");
            }

            return result;
        }

        #endregion
    }
}
