using inventory_backend.Dtos;

namespace inventory_backend.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
    }
}
