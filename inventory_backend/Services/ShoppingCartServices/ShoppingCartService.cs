using inventory_backend.Repository.ShoppingCartRepository;
using inventory_backend.Models;
using inventory_backend.Dtos;
using AutoMapper;
using inventory_backend.Mapper.CustomMapper;

namespace inventory_backend.Services.ShoppingCartService
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;
        public ShoppingCartService(IShoppingCartRepository shoppingRepo, IMapper mapper)
        {
            _shoppingCartRepository = shoppingRepo;
            _mapper = mapper;
        }

        public async Task<bool> CreateShoppingCart(Guid customerId)
        {
            try
            {
                if (await _shoppingCartRepository.CheckExistingShoppingCart(customerId))
                {
                    return true;
                }

                await _shoppingCartRepository.Add(new ShoppingCart()
                {
                    CustomerId = customerId
                });
                await _shoppingCartRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ShoppingCartResponseDto> GetShoppingCart(Guid customerId)
        {
            return (await _shoppingCartRepository.ReadyShoppingCartWithItems(customerId)).ToDto();
        }


    }
}
