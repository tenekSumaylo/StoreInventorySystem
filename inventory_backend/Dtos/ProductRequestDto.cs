using inventory_backend.Models;

namespace inventory_backend.Dtos
{
    public sealed record ProductRequestDto(Guid CategoryId, string ProductName, string Brand, double Price,
        int Stock, byte[]? ProductImage);
}
