using BookStore.Entities.DTOs.Author;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Validation.Author
{
    public class AuthorCreateValidator : AbstractValidator<AuthorCreateDto>
    {
        public AuthorCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
