using BookStore.Entities.DTOs.Category;
using FluentValidation;

namespace BookStore.Bussiness.Validation.Category
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name can not be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Category description can not be empty");
        }
    }
}
