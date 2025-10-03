using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Repository.CategoryRepository;

namespace inventory_backend.Services.Categories
{
    public class CategoryService(ICategoryRepository repo, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryService = repo;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CategoryDto>> GetAllCategories() => _mapper.Map<IEnumerable<CategoryDto>>(await _categoryService.Read());
      
    }
}
