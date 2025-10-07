using inventory_backend.Models;

namespace inventory_backend.Dtos
{
    public sealed record ProductRequestDto(string CategoryId, string ProductName, string Brand, double Price,
        int Stock, IEnumerable<TagRequestDto> Tags, byte[]? ProductImage);

    public sealed record ProductRequestDtoV1(Guid CategoryId, string ProductName, string Brand, double Price,
    int Stock, IEnumerable<TagRequestDto> Tags, byte[]? ProductImage);
}
