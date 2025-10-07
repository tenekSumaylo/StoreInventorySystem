namespace inventory_backend.Dtos
{
    public sealed record ProductResponseDto(Guid Id, string ProductName, string Brand, double Price,
        int Stock, IEnumerable<TagResponseDto> Tags, byte[]? ProductImage);
}
