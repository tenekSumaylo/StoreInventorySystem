using inventory_backend.Data;
using inventory_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly InventorySystemDbContext _systemDbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(InventorySystemDbContext _context)
        {
            _systemDbContext = _context;
            _dbSet = _systemDbContext.Set<TEntity>();
        }

        public async Task<bool> Add(TEntity item)
        {
            if (item is not null)
            {
                if (!_dbSet.Contains(item))
                {
                    await _dbSet.AddAsync(item);
                    await _systemDbContext.SaveChangesAsync();
                    return true;
                }

            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var data = await _dbSet.FindAsync(id);
            if (data is not null && data is TEntity entity)
            {
                _dbSet.Remove(entity);
                await _systemDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TEntity>> Read()
        {
            return await _dbSet.ToListAsync() ?? [];
        }

        public async Task<TEntity> ReadById(Guid id) => await _dbSet.SingleAsync(i => i.Id == id) ?? throw new Exception("");
        

        public async Task<bool> Update(Guid id, TEntity item)
        {
            var data = await _dbSet.FindAsync(id);
            if (data is not null && data is TEntity entity)
            {
                _dbSet.Update(entity);
                await _systemDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
