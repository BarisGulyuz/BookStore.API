using BookStore.Core.Results;
using BookStore.Entities.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
