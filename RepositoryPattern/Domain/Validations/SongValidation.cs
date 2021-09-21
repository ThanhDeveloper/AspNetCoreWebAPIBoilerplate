
using FluentValidation;
using RepositoryPattern.Domain.Command;

namespace RepositoryPattern.Domain.Validations
{
    public class SongValidation : AbstractValidator<SongCommand>
    {
        public void ValidateID()
        {
            RuleFor(p => p.id)
                .GreaterThan(0).WithMessage("The ID must be greater than zero");
        }

        public void ValidateTitle()
        {
            RuleFor(p => p.title)
                .NotEmpty().WithMessage("The Title cannot be empty")
                .MaximumLength(150).WithMessage("The Title must be a maximum of 150 characters");
        }

        public void ValidateAuthor()
        {
            RuleFor(p => p.author)
                .NotEmpty().WithMessage("The Author cannot be empty")
                .MaximumLength(150).WithMessage("The Author must be a maximum of 150 characters");
        }

        public void ValidateCategory()
        {
            RuleFor(p => p.category)
                .NotEmpty().WithMessage("The Category cannot be empty")
                .MaximumLength(150).WithMessage("The Category must be a maximum of 150 characters");
        }

        public void ValidateQuantity()
        {
            RuleFor(p => p.quantity)
                .GreaterThan(0).WithMessage("The Quantity must be greater than zero");
        }

        public void ValidatePrice()
        {
            RuleFor(p => p.price)
                .GreaterThan(0).WithMessage("The Price must be greater than zero");
        }
    }
}
