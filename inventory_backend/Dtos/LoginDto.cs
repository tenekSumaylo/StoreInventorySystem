using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Dtos
{
    public sealed record LoginDto(
        [Required][MinLength(1)] string UserLogin, [Required][MinLength(1)] string Password   
     );
}
