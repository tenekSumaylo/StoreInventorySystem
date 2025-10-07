using inventory_backend.Dtos;
using inventory_backend.Services.CheckoutServices;
using inventory_backend.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutServices _checkoutService;
        public CheckoutController(ICheckoutServices checkout)
        {
            _checkoutService = checkout;
        }

        [HttpPost]
        public async Task<IActionResult> CheckoutItems(CheckoutRequestDto dto)
        {
            try
            {

                var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("User non-existent");
                if (!(await _checkoutService.CheckoutAsync(dto, Guid.Parse(customerId))))
                {
                    throw new Exception("No items to checkout");
                }
                if (await _checkoutService.UnitOfWorkSaveChangesAsync())
                {
                    return Ok(true);
                }
                throw new Exception("Failure of save changes");

            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message, ex.InnerException });
            }
;        }
    }
}
