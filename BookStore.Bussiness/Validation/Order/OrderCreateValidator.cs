using BookStore.Entities.DTOs.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
