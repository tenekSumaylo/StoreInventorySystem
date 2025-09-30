using inventory_backend.Dtos;

namespace inventory_backend.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
    }
}
