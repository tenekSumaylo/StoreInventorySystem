namespace inventory_backend.Models
{
    public class ShoppingCartItem : Entity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid ShoppingCart { get; set; }
        public ShoppingCart? Cart { get; set; }
    }
}
