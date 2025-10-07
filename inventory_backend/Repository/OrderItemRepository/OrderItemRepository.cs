using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.OrderItemRepository
{
    public class OrderItemRepository : GenericRepository<OrderItems>, IOrderItemRepository
    {
        public OrderItemRepository(InventorySystemDbContext context) : base(context) { }
    }
}
