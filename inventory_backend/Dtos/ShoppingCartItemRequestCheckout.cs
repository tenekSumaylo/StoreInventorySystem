namespace inventory_backend.Dtos
{
    public sealed record ShoppingCartItemRequestCheckout(Guid Id, Guid ShoppingCartId, ProductCheckoutRequestDto Product, int Quantity);
}
