using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Core.Results;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
using BookStore.Entities.DTOs.OrderLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class OrderLineManager : IOrderLineService
    {
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IMapper _mapper;

        public OrderLineManager(IOrderLineRepository orderLineRepository, IMapper mapper)
        {
            _orderLineRepository = orderLineRepository;
            _mapper = mapper;
        }

        public async Task AddOrderLinesAsync(List<OrderLine> orders)
        {
            await _orderLineRepository.AddRangeAsync(orders);
        }

        public async Task<DataResult<List<OrderLineGetDto>>> GetOrderLineByOrderIdAsync(int orderId)
        {
            List<OrderLine> orderLines = await _orderLineRepository.GetAllAsync(x => x.Id == orderId);
            if (orderLines.Count > 0)
            {
                var orderLinesReturn = _mapper.Map<List<OrderLineGetDto>>(orderLines);
                return DataResult<List<OrderLineGetDto>>.Success(orderLinesReturn);
            }
            return DataResult<List<OrderLineGetDto>>.Failure("There is no data for this query");
        }
    }
}
