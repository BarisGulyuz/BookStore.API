using BookStore.Entities.DTOs.User;
using FluentValidation;

namespace BookStore.Bussiness.Validation.User
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Enter a valid email");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname can not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password can not be empty");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords must be same");
        }
    }
}
