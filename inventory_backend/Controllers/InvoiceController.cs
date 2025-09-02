using inventory_backend.Data;
using inventory_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InventorySystemDbContext _context;
        private readonly DbSet<Invoice> _dbSet;

        public InvoiceController(InventorySystemDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Invoice>();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Invoice item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(await _dbSet.ToListAsync() ?? []);
        }
    }
}
