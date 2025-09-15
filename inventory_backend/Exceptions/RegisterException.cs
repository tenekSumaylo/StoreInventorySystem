using Microsoft.AspNetCore.Identity;

namespace inventory_backend.Exceptions
{
    public class RegisterException : Exception
    {
        public IdentityResult? IdentityResult { get; set; } 
        public FluentValidation.Results.ValidationResult? ValidationResult { get; set; }

        public RegisterException() { }

        public RegisterException(string message) : base(message) { }

        public RegisterException(string message, IdentityResult result) : base(message) {
            IdentityResult = result;
        }

        public RegisterException(string message, FluentValidation.Results.ValidationResult result) : base(message)
        {
            ValidationResult = result;
        }

        public RegisterException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public RegisterException(string? message, Exception? innerException, IdentityResult result) : base(message, innerException)
        {
            IdentityResult = result;
        }

        public RegisterException(string? message, Exception? innerException, FluentValidation.Results.ValidationResult result) : base(message, innerException)
        {
            ValidationResult = result;
        }
    }
}
