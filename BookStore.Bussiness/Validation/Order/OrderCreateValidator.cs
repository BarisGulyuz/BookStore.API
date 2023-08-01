using BookStore.Entities.DTOs.Order;
using FluentValidation;

namespace BookStore.Bussiness.Validation
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateValidator()
        {
            RuleFor(x => x.Adress).NotEmpty();
            RuleFor(x => x.Note).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
        }
    }
}
