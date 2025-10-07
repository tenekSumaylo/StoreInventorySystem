namespace inventory_backend.Models
{
    public class ShoppingCart : Entity
    {
        public Guid CustomerId { get; set; }
        public ICollection<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
