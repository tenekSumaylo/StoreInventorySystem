using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProducts();
        Task<bool> AddProduct(ProductRequestDto product);
    }
}
