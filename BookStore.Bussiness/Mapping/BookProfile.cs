using AutoMapper;
using BookStore.Entities;
using BookStore.Entities.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
