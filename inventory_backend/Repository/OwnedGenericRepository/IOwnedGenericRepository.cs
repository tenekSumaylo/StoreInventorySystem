using inventory_backend.Models;

namespace inventory_backend.Repository.OwnedGenericRepository
{
    public interface IOwnedGenericRepository<TEntity> where TEntity : Entity, IEntityOwnership
    {
        Task<IEnumerable<TEntity>> GetOwnedItems(Guid customerId);
    }
}
