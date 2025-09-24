using inventory_backend.Data;
using inventory_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly InventorySystemDbContext _context;
        private readonly DbSet<Category> _dbSet;
        public CategoryController( InventorySystemDbContext context )
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbSet.ToListAsync() ?? []);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _dbSet.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        } 
    }
}
