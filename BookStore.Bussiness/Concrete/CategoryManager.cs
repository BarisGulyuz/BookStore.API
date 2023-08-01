using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Core.DataAccess.Abstract;
using BookStore.Core.Results;
using BookStore.Entities;
using BookStore.Entities.DTOs.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryManager(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Result> AddAsync(CategoryCreateDto categoryCreateDto)
        {
            Category category = _mapper.Map<Category>(categoryCreateDto);
            await _categoryRepository.AddAsync(category, autoSave: true);
            return Result.Success("Category Added Succesfully");
        }

        public async Task<Result> DeleteAsync(int categoryId)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == categoryId);
            if (category == null)
            {
                return Result.Failure("Category is not found");
            }
            await _categoryRepository.DeleteAsync(category, autoSave: true);
            return Result.Success();
        }

        public async Task<DataResult<List<CategoryGetDto>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync(x => x.Status == true);
            if (categories.Count > 0)
            {
                var categoriesReturn = _mapper.Map<List<CategoryGetDto>>(categories);
                return DataResult<List<CategoryGetDto>>.Success(categoriesReturn);
            }
            return DataResult<List<CategoryGetDto>>.Failure("There is no data to return");
        }

        public async Task<DataResult<CategoryGetDto>> GetByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                var categoryReturn = _mapper.Map<CategoryGetDto>(category);
                return DataResult<CategoryGetDto>.Success(categoryReturn);
            }
            return DataResult<CategoryGetDto>.Failure("There is no data to return");
        }

        public async Task<Result> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var oldCategory = await _categoryRepository.GetAsync(x => x.Id == categoryUpdateDto.Id);
            if (oldCategory != null)
            {
                var category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory);
                await _categoryRepository.UpdateAsync(category, autoSave: true);
                return Result.Success();
            }
            return Result.Failure("There is no category for this query");
        }
    }
}
