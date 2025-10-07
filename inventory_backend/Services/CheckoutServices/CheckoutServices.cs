
using inventory_backend.Dtos;
using inventory_backend.Mapper.CustomMapper;
using inventory_backend.Models;
using inventory_backend.UnitOfWorkPattern;

namespace inventory_backend.Services.CheckoutServices
{
    public class CheckoutServices : ICheckoutServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckoutAsync(CheckoutRequestDto dto, Guid customerId)
        {
            try
            {
                var orderItems = new List<OrderItems>();
                var shoppingCart = await _unitOfWork.ShoppingCartRepository.ReadyShoppingCartWithItems(customerId);
                if (!shoppingCart.CartItems.Any())
                {
                    return false;
                }

                foreach (var item in shoppingCart.CartItems)
                {
                    item.Product!.Stock = item.Product!.Stock - item.Quantity > -1 ? item.Product!.Stock - item.Quantity : throw new Exception("Invalid Product Validation");
                    _unitOfWork.ProductRepository.Update(item.Product);  // update products
                    await _unitOfWork.ShoppingCartItemRepository.Delete(item.Id); // delete shopping cart items
                    orderItems.Add(new OrderItems
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                    });
                }
                await _unitOfWork.OrderRepository.Add(new Order()
                {
                    TotalAmount = dto.SubTotal,
                    OrderDate = DateTime.Now,
                    CustomerId = customerId,
                    Items = orderItems
                });
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UnitOfWorkSaveChangesAsync()
        {
            try
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
