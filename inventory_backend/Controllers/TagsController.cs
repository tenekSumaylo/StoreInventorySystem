using inventory_backend.Services.Tags;
using Microsoft.AspNetCore.Mvc;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController(ITagService tagService) : ControllerBase
    {
        private readonly ITagService _tagService = tagService;


        [HttpGet]
        public async Task<IActionResult> GetAllTags() =>  Ok(new { Keywords = await _tagService.GetTags() });

    }
}
