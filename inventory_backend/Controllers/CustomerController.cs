using inventory_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(CustomerService service, ILogger<CustomerController> logger )
        {
            _service = service;
            _logger = logger;
        }

    }
}
