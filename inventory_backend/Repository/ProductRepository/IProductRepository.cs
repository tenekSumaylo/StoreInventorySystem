using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> PaginatedItemsSearch(string? searchParams, int page = 1, int pageSize = 12, Product? status = null);
        Task<IEnumerable<Product>> ReadWithTags();
    }
}