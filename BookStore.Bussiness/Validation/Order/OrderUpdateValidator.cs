using BookStore.Entities.DTOs.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
