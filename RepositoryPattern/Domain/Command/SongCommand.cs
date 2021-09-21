using FluentValidation.Results;
using RepositoryPattern.Domain.Validations;
using System;

namespace RepositoryPattern.Domain.Command
{
    public class SongCommand
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public DateTime created_date { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            var validation = new SongValidation();
            validation.ValidateID();
            validation.ValidateTitle();
            validation.ValidateAuthor();
            validation.ValidateCategory();
            validation.ValidateQuantity();
            validation.ValidatePrice();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
