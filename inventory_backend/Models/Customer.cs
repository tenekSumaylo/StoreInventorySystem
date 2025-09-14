using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Customer : IdentityUser
    {
        [Required]
        [MinLength(1, ErrorMessage = "Must be 1 or more characters....")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Must be 1 or more charaters...")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
