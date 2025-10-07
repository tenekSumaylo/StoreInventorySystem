using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProducts();
        Task<bool> AddProduct(ProductRequestDto product);
        Task<IEnumerable<ProductResponseDto>> GetProducts(string? searchParams, int page = 1, int pageSize = 12, ProductRequestDto? product = null);
        Task<bool> UpdateProduct(Guid id, ProductRequestDto dto);
    }
}
