using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Customer : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}
