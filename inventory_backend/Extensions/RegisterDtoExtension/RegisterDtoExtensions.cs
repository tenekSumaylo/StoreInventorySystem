using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Extensions.RegisterDtoExtension
{
    public static class RegisterDtoExtensions
    {
        public static Customer MapToCustomer(this RegisterDto dto) => new Customer
        {
            UserName = dto.Username,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Address = dto.Address,
        };
    }
}
