using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.OrderRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
