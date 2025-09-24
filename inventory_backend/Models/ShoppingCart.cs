namespace inventory_backend.Models
{
    public class ShoppingCart : Entity
    {
        Guid CustomerId { get; set; }
        Customer? Customer { get; set; }
        public ICollection<CartItems>? CartItems { get; set; }
    }
}
