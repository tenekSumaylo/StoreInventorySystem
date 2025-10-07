namespace inventory_backend.Dtos
{
    public sealed record ShoppingCartResponseDto(Guid ShoppingCartId, IEnumerable<ShoppingCartItemResponseDto> CartItems);

    // guid
    // cartitems
}
