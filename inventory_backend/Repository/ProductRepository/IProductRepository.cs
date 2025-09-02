using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
