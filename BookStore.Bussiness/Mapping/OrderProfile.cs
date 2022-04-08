using AutoMapper;
using BookStore.Entities;
using BookStore.Entities.DTOs.Order;
using BookStore.Entities.DTOs.OrderLine;

namespace BookStore.Bussiness.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderGetDto, Order>().ReverseMap();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();

            CreateMap<OrderLineGetDto, OrderLine>().ReverseMap();
            CreateMap<OrderLineCreateDto, OrderLine>();
        }
    }
}
