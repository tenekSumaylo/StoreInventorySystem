using inventory_backend.Models;
using inventory_backend.Services.ShoppingCartService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _cartService;
        public ShoppingCartController(IShoppingCartService cartService)
        {
            _cartService = cartService;

        }

        [HttpPost]
        public async Task<IActionResult> AddShoppingCart()
        {
            try
            {
                var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("There is not customer id found");
                return Ok( await _cartService.CreateShoppingCart(Guid.Parse(customerId)));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCart()
        {
            try
            {
                var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("There is not customer id found");
                return Ok( await _cartService.GetShoppingCart(Guid.Parse(customerId)));
            }
            catch (Exception ex)
            {
                return BadRequest( new { ex.Message, ex.InnerException });
            }
        }
    }
}
