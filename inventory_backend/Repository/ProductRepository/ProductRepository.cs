using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(InventorySystemDbContext _context ) : base( _context ) { } 
    }
}
