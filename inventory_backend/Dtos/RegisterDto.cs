using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace inventory_backend.Dtos
{
    public sealed record RegisterDto(
        [Required] string Username, [Required] string Password, [Required][EmailAddress] string Email, [Required] string FirstName, 
        [Required] string LastName, [Optional] string Address
     );
}
