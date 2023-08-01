using BookStore.Entities.DTOs.Book;
using FluentValidation;

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
