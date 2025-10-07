using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequestDto, Product>().ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(t => new ProductTag { Id = t.Id})));
            CreateMap<Product, ProductRequestDto>();
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
