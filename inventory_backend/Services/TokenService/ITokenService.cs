using inventory_backend.Models;

namespace inventory_backend.Services.TokenService
{
    public interface ITokenService
    {
        string? GenerateToken(Customer user);
    }
}
