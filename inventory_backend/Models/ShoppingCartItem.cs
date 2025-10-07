namespace inventory_backend.Models
{
    public class ShoppingCartItem : Entity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart? Cart { get; set; }
        public int Quantity { get; set; }
    }
}
