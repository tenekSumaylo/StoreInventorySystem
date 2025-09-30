namespace inventory_backend.Exceptions
{
    public class ProductException : Exception
    {
        public FluentValidation.Results.ValidationResult? ValidationResult { get; set; }
        public ProductException() : base("Product exception occurred") { }

        public ProductException(string message) : base(message)
        {

        }

        public ProductException( string message,  Exception innerException ) : base(message, innerException) { }

        public ProductException(string message, FluentValidation.Results.ValidationResult result) : base(message)
        {
            ValidationResult = result;
        }


    }
}
