using Microsoft.AspNetCore.Identity;

namespace inventory_backend.Exceptions
{
    public class RegisterException : Exception
    {
        public IdentityResult IdentityResult { get; set; } = new();

        public RegisterException() { }

        public RegisterException(string message) : base(message) { }

        public RegisterException(string message, IdentityResult result) : base(message) {
            IdentityResult = result;
        }

        public RegisterException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public RegisterException(string? message, Exception? innerException, IdentityResult result) : base(message, innerException)
        {
            IdentityResult = result;
        }
    }
}
