using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Mapper
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tags, TagResponseDto>().ForMember(to => to.Tag, opt => opt.MapFrom(i => i.Tag));
            CreateMap<Tags, TagResponseDto>();
            CreateMap<TagRequestDto, Tags>();
            CreateMap<TagRequestDto, ProductTag>().ForMember(i => i.Id, opt => opt.MapFrom(src=> src.Id));
            CreateMap<ProductTag, TagRequestDto>();
            CreateMap<ProductTag, TagResponseDto>().ConstructUsing(src => new TagResponseDto(src.Id, src!.Tag!.Tag));
            CreateMap<IEnumerable<ProductTag>, IEnumerable<TagResponseDto>>();
            CreateMap<TagResponseDto, ProductTag>();
        }
    }
}
