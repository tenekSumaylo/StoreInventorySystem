using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.ProductTagRepository
{
    public interface IProductTagRepository : IGenericRepository<ProductTag>
    {
    }
}
