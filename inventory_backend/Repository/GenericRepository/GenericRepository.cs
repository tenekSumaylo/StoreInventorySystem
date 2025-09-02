using inventory_backend.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System.Reflection.Metadata.Ecma335;


namespace inventory_backend.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly InventorySystemDbContext _systemDbContext;
        private readonly DbSet<TEntity> _dbSet;
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

        public async Task<bool> Delete(int id)
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

        public async Task<TEntity?> ReadById(int id)
        {
            return await _dbSet.FindAsync(id) ?? null;
        }

        public async Task<bool> Update(int id, TEntity item)
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
