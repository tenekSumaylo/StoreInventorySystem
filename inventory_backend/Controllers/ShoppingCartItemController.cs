using inventory_backend.Dtos;
using inventory_backend.Services.ShoppingCartItemServices;
using Microsoft.AspNetCore.Mvc;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemService _cartItemService;
        public ShoppingCartItemController(IShoppingCartItemService cartService)
        {
            _cartItemService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(ShoppingCartItemRequestDto dto)
        {
            try
            {
                if (await _cartItemService.AddShoppingCartItem(dto) is not true)
                {
                    throw new Exception("Failure to add shopping cart item");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message, ex.InnerException });
            }
        }

        [HttpPut("ItemQuantity")]
        public async Task<IActionResult> UpdateItemQuantity(UpdateCartItemRequestDto dto )
        {
            try
            {
                return Ok(await _cartItemService.UpdateShoppingCartItem(dto));
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message, ex.InnerException });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItemFromShoppingCart([FromBody]DeleteCartItemRequestDto dto)
        {
            try
            {
                return Ok(await _cartItemService.RemoveItemFromCart(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message, ex.InnerException });
            }
        }
    }
}
