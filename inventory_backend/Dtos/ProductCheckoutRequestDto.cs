namespace inventory_backend.Dtos
{
    public sealed record ProductCheckoutRequestDto(Guid Id, string ProductName, string Brand, double Price,
        int Stock, IEnumerable<TagRequestDto> Tags, byte[]? ProductImage);

}
