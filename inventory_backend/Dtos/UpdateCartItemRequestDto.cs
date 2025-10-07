namespace inventory_backend.Dtos
{
    public sealed record UpdateCartItemRequestDto(Guid Id, int Quantity);
}

/*        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart? Cart { get; set; }
        public int Quantity { get; set; }  */
