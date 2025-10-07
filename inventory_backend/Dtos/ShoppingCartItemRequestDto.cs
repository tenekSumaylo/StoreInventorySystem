namespace inventory_backend.Dtos
{
    public sealed record ShoppingCartItemRequestDto(Guid ProductId, Guid ShoppingCartId);

    /*         public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart? Cart { get; set; } */
}
