using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Must be 1 or more characters....")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Must be 1 or more charaters...")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Must be 1 or more characters...")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public ICollection<Invoice> Invoices { get; set; } = [];
    }
}
