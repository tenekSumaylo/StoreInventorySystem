using inventory_backend.Dtos;

namespace inventory_backend.Services.CheckoutServices
{
    public interface ICheckoutServices
    {
        Task<bool> CheckoutAsync(CheckoutRequestDto dto, Guid customerId);
        Task<bool> UnitOfWorkSaveChangesAsync();
    }
}
