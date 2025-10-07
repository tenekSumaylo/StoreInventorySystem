using inventory_backend.Data;
using inventory_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
            try
            {
                if (item is not null)
                {
                    if (!_dbSet.Contains(item))
                    {
                        await _dbSet.AddAsync(item);
                        return true;
                    }

                }
                return false;
            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var data = await _dbSet.FindAsync(id);
                if (data is not null && data is TEntity entity)
                {
                    _dbSet.Remove(entity);
                    return true;
                }
                return false;
            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<IEnumerable<TEntity>> Read()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> ReadById(Guid id) => await _dbSet.SingleAsync(i => i.Id == id);
        

        public bool Update(Entity item)
        {
            try
            {
                _systemDbContext.Entry(item).State = EntityState.Modified;
                return true;
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _systemDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<IEnumerable<TEntity>> PaginatedItems(int page = 1, int pageSize = 12, TEntity? status = null)
        {
            return await _dbSet.Skip( ( page-1 ) * pageSize)
                .Take(pageSize).ToListAsync();
        }
    }
}
