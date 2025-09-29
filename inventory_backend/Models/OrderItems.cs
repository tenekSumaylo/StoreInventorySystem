namespace inventory_backend.Models
{
    public class OrderItems : Entity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }
        public Order? Order { get; set; }
    }
}
