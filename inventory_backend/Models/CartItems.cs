namespace inventory_backend.Models
{
    public class CartItems : Entity
    {
        Guid ProductId;
        Product Product { get; set; } = new();
    }
}
