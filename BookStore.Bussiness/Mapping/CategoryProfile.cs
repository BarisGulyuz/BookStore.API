using AutoMapper;
using BookStore.Entities;
using BookStore.Entities.DTOs.Category;

namespace BookStore.Bussiness.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryGetDto>().ReverseMap();
        }
    }
}
