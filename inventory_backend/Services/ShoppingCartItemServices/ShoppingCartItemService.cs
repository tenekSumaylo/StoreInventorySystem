using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models;
using inventory_backend.Repository.ShoppingCartItemRepository;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace inventory_backend.Services.ShoppingCartItemServices
{
    public class ShoppingCartItemService(IShoppingCartItemRepository repo, IMapper mapper) : IShoppingCartItemService
    {
        private readonly IShoppingCartItemRepository _cartItemRepository = repo;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> AddShoppingCartItem(ShoppingCartItemRequestDto dto)
        {
            try {
                var entityShoppingCart = _mapper.Map<ShoppingCartItem>(dto);
                var shoppingCartItemSearch = await _cartItemRepository.CheckExistingCartItem(entityShoppingCart.ProductId, entityShoppingCart.ShoppingCartId);
                if ( shoppingCartItemSearch.FirstOrDefault() is not null)
                {
                    var item = shoppingCartItemSearch.First();
                    if ( item.Product!.Stock > item.Quantity)
                    {
                        item.Quantity++;
                    }
                    else
                    {
                        return false;
                    }
                    _cartItemRepository.Update(item);
                    await _cartItemRepository.SaveChangesAsync();
                    return true;
                }
                entityShoppingCart.Quantity = 1;
                await _cartItemRepository.Add(entityShoppingCart);
                await _cartItemRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task<IEnumerable<ShoppingCartItemResponseDto>> GetShoppingCartItems(Guid customerId)
        {
            try
            {
                return _mapper.Map<IEnumerable<ShoppingCartItemResponseDto>>(await _cartItemRepository.Read());

            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateShoppingCartItem(UpdateCartItemRequestDto dto)
        {
            try
            {
                var item = (await _cartItemRepository.ReadCartItemWithProduct(dto.Id)).First() ?? throw new Exception("Shopping cart item not found");
                _mapper.Map<UpdateCartItemRequestDto, ShoppingCartItem>(dto, item);
                if (item.Product!.Stock < item.Quantity)
                {
                    return false;
                }
                if (item.Quantity == 0 )
                {
                    return false;
                }
                _cartItemRepository.Update(item);
                await _cartItemRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }


        }

        public async Task<bool> RemoveItemFromCart(DeleteCartItemRequestDto dto)
        {
            try
            {
                if (await _cartItemRepository.Delete(dto.Id))
                {
                    await _cartItemRepository.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
