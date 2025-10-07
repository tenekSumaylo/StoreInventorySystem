using inventory_backend.Dtos;

namespace inventory_backend.Services.ShoppingCartItemServices
{
    public interface IShoppingCartItemService
    {
        Task<bool> AddShoppingCartItem(ShoppingCartItemRequestDto dto);
        Task<IEnumerable<ShoppingCartItemResponseDto>> GetShoppingCartItems(Guid customerId); Task<bool> UpdateShoppingCartItem(UpdateCartItemRequestDto dto);
        Task<bool> RemoveItemFromCart(DeleteCartItemRequestDto dto);
    }
}
