using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Invoice : Entity
    {
        public Guid CustomerId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public ICollection<InvoiceItem>? Items { get; set; }
    }
}
