namespace inventory_backend.Dtos
{
    public sealed record ShoppingCartItemResponseDto(Guid Id, Guid ShoppingCartId, ProductResponseDto Product, int Quantity);
}
/*
 *      public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart? Cart { get; set; }
 * 
 * */