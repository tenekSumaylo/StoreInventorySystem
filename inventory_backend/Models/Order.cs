namespace inventory_backend.Models
{
    public class Order : Entity
    {
        public Guid CustomerId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate {  get; set; } = DateTime.Now;
        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<OrderItems>? Items { get; set; }
    }
}
