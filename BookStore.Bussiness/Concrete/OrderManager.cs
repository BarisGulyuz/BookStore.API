using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Bussiness.Extensions;
using BookStore.Core.Enums;
using BookStore.Core.Results;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
using BookStore.Entities.BasketEntities;
using BookStore.Entities.DTOs.Order;
using BookStore.Entities.DTOs.OrderLine;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderLineService _orderLineService;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly IValidator<OrderCreateDto> _createValidator;

        public OrderManager(IOrderRepository orderRepository, IOrderLineService orderLineService, IBasketService basketService, IMapper mapper, IValidator<OrderCreateDto> createValidator)
        {
            _orderRepository = orderRepository;
            _orderLineService = orderLineService;
            _basketService = basketService;
            _mapper = mapper;
            _createValidator = createValidator;
        }

        public async Task<Result> AddWithOrderLinesAsync(OrderCreateDto orderCreateDto, string basketId, int userId)
        {
            var result = _createValidator.Validate(orderCreateDto);
            if (result.IsValid)
            {
                Order order = _mapper.Map<Order>(orderCreateDto);
                order.UserId = userId;
                order.ShipmentStatus = (int)ShipmentStatusEnum.Waiting;
                order.Status = true;
                await _orderRepository.AddAsync(order);

                var basketResult = await _basketService.GetBasketAsync(basketId);
                if (basketResult.BasketItems.Count > 0)
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
                    await _orderLineService.AddOrderLinesAsync(orderLines);
                    return Result.Success();
                }
                return Result.Failure("There is no basket item yet");
            }
            return Result.Failure("Validation Error", result.ConvertToCustomValidationErrors());
        }


        public async Task<DataResult<List<OrderGetDto>>> GetOrdersAsync(int shipmentStatus)
        {
            List<Order> orders = new();
            switch (shipmentStatus == (int)ShipmentStatusEnum.All)
            {
                case true:
                    orders = await _orderRepository.GetAllAsync(null, x => x.OrderLines, x => x.User);
                    break;
                default:
                    orders = await _orderRepository.GetAllAsync(x => x.ShipmentStatus == shipmentStatus, x => x.OrderLines, x => x.User);
                    break;
            }
            if (orders.Count > 0)
            {
                List<OrderGetDto> orderGetRetun = _mapper.Map<List<OrderGetDto>>(orders);
                return DataResult<List<OrderGetDto>>.Success(orderGetRetun);
            }
            return DataResult<List<OrderGetDto>>.Failure("There is no data for this query");

        }

        public async Task<Result> DeleteAsync(int id)
        {
            Order order = await _orderRepository.GetAsync(x => x.Id == id);
            if (order != null)
            {
                await _orderRepository.DeleteAsync(order);
                return Result.Success();
            }
            return Result.Failure("There is no data for this query");
        }

    }
}
