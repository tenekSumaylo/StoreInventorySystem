using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Services.ShoppingCartService
{
    public interface IShoppingCartService
    {
        Task<bool> CreateShoppingCart(Guid customerId);
        Task<ShoppingCartResponseDto> GetShoppingCart(Guid customerId);
    }
}
