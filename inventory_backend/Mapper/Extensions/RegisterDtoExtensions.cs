using inventory_backend.Dtos;
using inventory_backend.Models;
namespace inventory_backend.Mapper.Extensions
{
    public static class RegisterDtoExtensions
    {
        public static Customer RegisterToCustomerEntity(this RegisterDto dto) => new()
        {
            UserName = dto.Username,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Address = dto.Address
        };
    }
}
