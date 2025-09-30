using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models;
using inventory_backend.Repository.ProductRepository;

namespace inventory_backend.Products
{
    public class ProductService(IProductRepository _product, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = _product;
        private readonly IMapper _mapper = mapper;
        public async Task<bool> AddProduct(ProductRequestDto product)
        {
            try
            {
                var result = await _productRepository.Add(_mapper.Map<Product>(product));
                if ( !result )
                {
                    throw new Exception("Adding product failed...");
                }
                await _productRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProducts() => _mapper.Map<IEnumerable<ProductResponseDto>>(await _productRepository.Read());
        
    }
}
