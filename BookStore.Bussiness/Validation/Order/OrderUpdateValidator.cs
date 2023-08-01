using BookStore.Entities.DTOs.Order;
using FluentValidation;

namespace BookStore.Bussiness.Validation
{
    public class OrderUpdateValidator : AbstractValidator<OrderUpdateDto>
    {
        public OrderUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Adress).NotEmpty();
            RuleFor(x => x.Note).NotEmpty();
            RuleFor(x => x.ShipmentStatus).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            //RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
