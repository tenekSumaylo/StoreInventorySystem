using inventory_backend.Categories;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService service )
        {
            _categoryService = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _categoryService.GetAllCategories());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message, ex });
            }
        }
    }
}
