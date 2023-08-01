using AutoMapper;
using BookStore.Entities;
using BookStore.Entities.DTOs.Role;

namespace BookStore.Bussiness.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleGetDto, Role>();
        }
    }
}
