using inventory_backend.Data;
using inventory_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Repository.OwnedGenericRepository
{
    public class OwnedGenericRepository<TEntity> : IOwnedGenericRepository<TEntity> where TEntity : Entity, IEntityOwnership
    {
        private readonly InventorySystemDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public OwnedGenericRepository(InventorySystemDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetOwnedItems(Guid customerId)
        {
            return await _dbSet.Where(i => i.CustomerId == customerId).ToListAsync();
        }
    }
}
