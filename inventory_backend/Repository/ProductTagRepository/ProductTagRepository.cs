using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;
using inventory_backend.Repository.ProductTagRepository;

namespace inventory_backend.Repository.ProductTagRepository
{
    public class ProductTagRepository : GenericRepository<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(InventorySystemDbContext context) : base(context){ }
    }
}
