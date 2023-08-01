using AutoMapper;
using BookStore.Entities;
using BookStore.Entities.DTOs.Author;

namespace BookStore.Bussiness.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<Author, AuthorGetDto>().ReverseMap();
        }
    }
}
