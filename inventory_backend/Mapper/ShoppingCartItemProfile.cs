using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Mapper
{
    public class ShoppingCartItemProfile : Profile
    {
        public ShoppingCartItemProfile()
        {
            CreateMap<ShoppingCartItem, ShoppingCartItemResponseDto>();
            CreateMap<ShoppingCartItemRequestDto, ShoppingCartItem>();
            CreateMap<UpdateCartItemRequestDto, ShoppingCartItem>();
        }
    }
}
/*public sealed record ProductResponseDto(Guid Id, string ProductName, string Brand, double Price,
    int Stock, IEnumerable<TagResponseDto> Tags, byte[]? ProductImage); */