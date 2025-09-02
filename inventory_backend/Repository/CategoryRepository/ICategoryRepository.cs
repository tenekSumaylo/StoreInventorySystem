using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
