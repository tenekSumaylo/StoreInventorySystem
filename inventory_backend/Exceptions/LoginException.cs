using Microsoft.AspNetCore.Identity;

namespace inventory_backend.Exceptions
{
    public class LoginException : Exception
    {

        public IdentityResult? Result { get; set; }
        public FluentValidation.Results.ValidationResult? ValidationResult { get; set; }
        public LoginException() { }

        public LoginException(string message) : base(message) { }
        public LoginException(string message, FluentValidation.Results.ValidationResult result) : base(message)
        {
            ValidationResult = result;
        }
        public LoginException(string message, IdentityResult result) : base(message)
        {
            Result = result;
        }

        public LoginException(string message,  Exception innerException) : base(message, innerException) { }

        public LoginException(string message, Exception innerException, IdentityResult result) : base(message, innerException)
        {
            Result = result;
        }

        public LoginException(string message, Exception innerException, FluentValidation.Results.ValidationResult? result) 
            : base(message, innerException)
        {
            ValidationResult = result;
        }

    }
}
