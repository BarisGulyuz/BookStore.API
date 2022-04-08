using BookStore.Entities.DTOs.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Validation.Category
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Category Id can not be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name can not be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Category description can not be empty");
        }
    }
}
