using FluentValidation;
using inventory_backend.Dtos;

namespace inventory_backend.Validations
{
    public class ProductRequestValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductRequestValidator()
        {
            RuleFor(i => i.Price).NotEmpty().NotNull().GreaterThan(0).WithMessage("Price cannot be 0 or less");
            RuleFor(i => i.Stock).NotEmpty().NotNull().GreaterThan(0).WithMessage("Stock cannot be 0 or less");
            RuleFor(i => i.CategoryId).NotEmpty().NotNull().WithMessage("Category cannot be empty");
            RuleFor(i => i.ProductName).NotEmpty().NotNull().WithMessage("Product name must not be empty");
        }
    }
}
