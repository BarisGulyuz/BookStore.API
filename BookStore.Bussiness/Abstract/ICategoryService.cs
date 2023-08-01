using BookStore.Core.Results;
using BookStore.Entities.DTOs.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface ICategoryService
    {
        Task<DataResult<List<CategoryGetDto>>> GetAllAsync();
        Task<DataResult<CategoryGetDto>> GetByIdAsync(int categoryId);
        Task<Result> AddAsync(CategoryCreateDto categoryCreateDto);
        Task<Result> DeleteAsync(int categoryId);
        Task<Result> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
    }
}
