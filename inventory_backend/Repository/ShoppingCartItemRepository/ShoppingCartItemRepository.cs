using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Repository.ShoppingCartItemRepository
{
    public class ShoppingCartItemRepository : GenericRepository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(InventorySystemDbContext context) : base(context) { }

        public async Task<IEnumerable<ShoppingCartItem>> CheckExistingCartItem(Guid productId)
        {
            return (await _dbSet.Where(i => i.ProductId.Equals(productId))
                .Include(x => x.Product).ToListAsync());
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsByCustomer(Guid shoppingCartId) => await _dbSet.Where(i => i.ShoppingCartId == shoppingCartId).ToListAsync();

        public async Task<IEnumerable<ShoppingCartItem>> ReadCartItemWithProduct(Guid Id) => await _dbSet.Where(i => i.Id == Id)
                                                                                            .Include(x => x.Product).ToListAsync();
    }
}
