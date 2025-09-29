using inventory_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace inventory_backend.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity item);
        bool Update(Entity item);
        Task<IEnumerable<TEntity>> Read();
        Task<TEntity> ReadById(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
