using Microsoft.AspNetCore.Identity;

namespace inventory_backend.Models.Users
{
    public abstract class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
