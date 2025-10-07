using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Mapper
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartResponseDto>();
        }
    }
}
