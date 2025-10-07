using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Repository.ShoppingCartRepository
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(InventorySystemDbContext context) : base(context) { }

        public async Task<bool> CheckExistingShoppingCart(Guid customerId)
        {
            return (await _dbSet.Where(i => i.CustomerId.Equals(customerId)).ToListAsync()).FirstOrDefault() is not null;
        }

        public async Task<ShoppingCart> ReadyShoppingCartWithItems(Guid customerId)
        {
            return (await _dbSet.Where(i => i.CustomerId.Equals(customerId))
                .Include(i => i.CartItems)
                .ThenInclude(i => i.Product)
                //.ThenInclude(x => x.Cart)
                .ToListAsync()).First();
        }
    }
}
