using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Bussiness.Extensions;
using BookStore.Core.Results;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
using BookStore.Entities.DTOs.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryCreateDto> _createValidator;
        private readonly IValidator<CategoryUpdateDto> _updateValidator;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CategoryCreateDto> createValidator, IValidator<CategoryUpdateDto> updateValidator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Result> AddAsync(CategoryCreateDto categoryCreateDto)
        {
            var result = _createValidator.Validate(categoryCreateDto);
            if (result.IsValid)
            {
                var category = _mapper.Map<Category>(categoryCreateDto);
                await _categoryRepository.AddAsync(category);
                return Result.Success("Category Added Succesfully");
            }
            return Result.Failure("Validation Error", result.ConvertToCustomValidationErrors());
        }

        public async Task<Result> DeleteAsync(int categoryId)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == categoryId);
            if (category == null) return Result.Failure("Category is not found");
            await _categoryRepository.DeleteAsync(category);
            return Result.Success();
        }

        public async Task<DataResult<List<CategoryGetDto>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync(x => x.Status);
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
            var result = _updateValidator.Validate(categoryUpdateDto);
            if (result.IsValid)
            {
                var oldCategory = await _categoryRepository.GetAsync(x => x.Id == categoryUpdateDto.Id);
                if (oldCategory != null)
                {
                    var category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory);
                    await _categoryRepository.Update(category);
                    return Result.Success();
                }
                return Result.Failure("There is no category for this query");
            }
            return Result.Failure("Validation Error", result.ConvertToCustomValidationErrors());
        }
    }
}
