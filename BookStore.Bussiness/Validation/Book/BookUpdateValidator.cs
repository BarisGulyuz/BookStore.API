using BookStore.Entities.DTOs.Book;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Validation.Book
{
    public class BookUpdateValidator : AbstractValidator<BookUpdateDto>
    {
        public BookUpdateValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.NumberofPages).NotEmpty();
            RuleFor(x => x.Subject).NotEmpty().MaximumLength(100).MaximumLength(5000);
        }
    }
}
