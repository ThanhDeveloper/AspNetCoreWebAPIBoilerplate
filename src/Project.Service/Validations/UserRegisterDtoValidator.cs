using FluentValidation;
using Project.Core.DTOs.Users;

namespace Project.Service.Validations;

public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterDtoValidator()
    {
        RuleFor(x => x.UserName).
            NotNull().WithMessage("Username is required")
            .NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Password is required")
            .NotEmpty().WithMessage("Password is required");
        RuleFor(x => x.DisplayName)
            .NotNull().WithMessage("Display name is required")
            .NotEmpty().WithMessage("Display name is required");
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Email is required")
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email address is required.");;
    }
}