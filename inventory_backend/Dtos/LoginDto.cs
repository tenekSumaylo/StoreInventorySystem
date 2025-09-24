using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Dtos
{
    public sealed record LoginDto(string UserLogin,  string Password);
}
