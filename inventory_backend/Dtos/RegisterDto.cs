using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace inventory_backend.Dtos
{
    public sealed record RegisterDto(
       string Username, string Password, string Email, string FirstName,  string LastName, string Address, DateOnly DateOfBirth
     );
}
