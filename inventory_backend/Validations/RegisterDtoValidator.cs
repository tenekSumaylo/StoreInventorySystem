using FluentValidation;
using inventory_backend.Dtos;

namespace inventory_backend.Validations
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(i => i.Username).NotNull().NotEmpty();
            RuleFor(i => i.Password).NotNull().NotEmpty();
            RuleFor(i => i.FirstName).NotNull().NotEmpty();
            RuleFor(i => i.LastName).NotNull().NotEmpty();
            RuleFor(i => i.Address).NotNull().NotEmpty();
            RuleFor(i => i.Email).NotNull().NotEmpty();
            RuleFor(i => i.DateOfBirth).NotNull().NotEmpty();
        }
    }
}
