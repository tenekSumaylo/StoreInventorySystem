using inventory_backend.Models;

namespace inventory_backend.TokenServices
{
    public interface ITokenService
    {
        string? GenerateToken(Customer user);
    }
}
