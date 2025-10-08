using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Repository.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(InventorySystemDbContext _context ) : base( _context ) { }

        public async Task<IEnumerable<Product>> PaginatedItemsSearch(string? searchParams, int page = 1, int pageSize = 12, Product? status = null)
        {
            if ( searchParams is not null )
            {
                return await _dbSet.Where(i => i.ProductName.Contains(searchParams))
                    .Skip((page - 1) * pageSize)
                    .Include(x => x.Tags)
                    .ThenInclude(x => x.Tag)
                    .Take(pageSize)
                    .ToListAsync();
            }
            return await _dbSet.Include(x => x.Tags)
                .ThenInclude(x => x.Tag)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> ReadWithTags()
        {
            return await _dbSet.Include(x => x.Tags).ThenInclude(x=> x.Tag).ToListAsync();
        }
    }
}
