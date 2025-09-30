using inventory_backend.Models.Users;

namespace inventory_backend.TokenServices
{
    public interface ITokenService
    {
        string? GenerateToken(ApplicationUser user, IList<string>? roles);
    }
}
