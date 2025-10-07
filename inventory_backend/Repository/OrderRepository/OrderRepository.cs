using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.OrderRepository
{
    public class OrderRepository: GenericRepository<Order>, IOrderRepository
    {

        public OrderRepository(InventorySystemDbContext context) : base(context) { }
    }
}
