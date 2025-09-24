using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Invoice : Entity
    {
        public Guid CustomerId { get; set; }
        public double TotalAmount { get; set; }
        public DateOnly InvoiceDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public ICollection<InvoiceItem>? InvoiceItems { get; set; }
    }
}
