using FluentValidation;
using inventory_backend.Dtos;

namespace inventory_backend.Validations
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UserLogin).NotEmpty().NotNull().WithMessage("User login must not be not nor empty");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password must not be null nor empty");
        }
    }
}
