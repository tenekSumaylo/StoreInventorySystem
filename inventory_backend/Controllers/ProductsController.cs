using FluentValidation;
using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Products;
using inventory_backend.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService, IValidator<ProductRequestDto> prodValidator) : ControllerBase
    {
        private readonly IProductService _productService = productService;
        private readonly IValidator<ProductRequestDto> _productValidator = prodValidator;


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequestDto dto)
        {
            try
            {
                var validations = await _productValidator.ValidateAsync(dto);
                if (!validations.IsValid)
                {
                    throw new ProductException();
                }
                var addProduct = await _productService.AddProduct(dto);
                return Ok(addProduct);
            }
            catch ( ProductException ex )
            {
                return BadRequest(ex.ValidationResult is not null ? new {ex.ValidationResult.Errors} : new { ex.Message});
            }
            catch ( Exception ex )
            {
                return BadRequest(new { ex.Message, ex.InnerException });
            }
        }
    }
}
