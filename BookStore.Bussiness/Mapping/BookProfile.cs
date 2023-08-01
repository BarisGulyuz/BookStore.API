using AutoMapper;
using BookStore.Entities;
using BookStore.Entities.DTOs.Book;

namespace BookStore.Bussiness.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<Book, BookGetDto>().ReverseMap();
        }
    }
}
