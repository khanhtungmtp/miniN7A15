
using System.Globalization;
using API.Configuration;
using API.Dtos;
using FluentValidation;
using FluentValidation.Resources;

namespace API._Validators
{
    public class CreateProductValidator : AbstractValidator<ProductCreateDto>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Product name is required")
                .Length(5, 150)
                .WithMessage("Product name must be between 5 and 150 characters long");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithErrorCode("NotNullValidator")
                .Must(s => s >= 0)
                .WithMessage("Stock must be greater than 0");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Price is required")
                .Must(p => p >= 0)
                .WithMessage("Price must be greater than 0");

        }
    }


}