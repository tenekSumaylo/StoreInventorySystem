namespace inventory_backend.Dtos
{
    public sealed record CheckoutRequestDto(Guid ShoppingCartId, IEnumerable<ShoppingCartItemRequestCheckout> CartItems, double SubTotal);
 
    public sealed record CheckoutRequestDtoV1(string ShoppingCartId, IEnumerable<ShoppingCartItemRequestCheckout> CartItems, double SubTotal);
}
