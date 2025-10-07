using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.ShoppingCartItemRepository
{
    public interface IShoppingCartItemRepository : IGenericRepository<ShoppingCartItem>
    {
        Task<IEnumerable<ShoppingCartItem>> CheckExistingCartItem(Guid productId);
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsByCustomer(Guid shoppingCartId);
        Task<IEnumerable<ShoppingCartItem>> ReadCartItemWithProduct(Guid Id);
    }
}
