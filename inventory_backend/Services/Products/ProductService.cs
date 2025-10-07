using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models;
using inventory_backend.Repository.ProductRepository;
using inventory_backend.Mapper.CustomMapper;
namespace inventory_backend.Services.Products
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

        public async Task<IEnumerable<ProductResponseDto>> GetAllProducts() => (await _productRepository.ReadWithTags()).ToDto();

        public async Task<IEnumerable<ProductResponseDto>> GetProducts(string? searchParams,int page = 1, int pageSize = 12, ProductRequestDto? product = null)
        {
            try
            {
                Product? entityProduct = null; 
                if (product is not null)
                {
                    entityProduct = _mapper.Map<Product>(product);
                }

                return (await _productRepository.PaginatedItemsSearch(searchParams, page, pageSize, entityProduct)).ToDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateProduct(Guid id, ProductRequestDto dto )
        {
            try
            {
                var item = await _productRepository.ReadById(id);
                if (item is null)
                {
                    throw new Exception("Item not found");
                }
                _mapper.Map<ProductRequestDto, Product>(dto, item);
                _productRepository.Update(item);
                await _productRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
