namespace inventory_backend.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Checkout();
        Task<bool> SaveChangesAsync();
    }
}
