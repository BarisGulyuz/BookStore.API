using AutoMapper;
using BookStore.Entities;
using BookStore.Entities.DTOs.User;

namespace BookStore.Bussiness.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserGetDto>().ReverseMap();
        }
    }
}
