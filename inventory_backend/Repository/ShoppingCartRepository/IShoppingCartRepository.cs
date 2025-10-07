using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.ShoppingCartRepository
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        public Task<bool> CheckExistingShoppingCart(Guid customerId);
        Task<ShoppingCart> ReadyShoppingCartWithItems(Guid customerId);
    }
}
