using FluentValidation;
using Project.Core.DTOs.Users;

namespace Project.Service.Validations;

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull().WithMessage("User name is required")
            .NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Password is required")
            .NotEmpty().WithMessage("{PropertyName} is required");
    }
}