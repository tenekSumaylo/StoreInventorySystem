using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
