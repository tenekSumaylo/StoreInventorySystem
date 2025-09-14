using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Invoice : Entity
    {

        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalAmount { get; set; }

        [Required]
        public DateOnly InvoiceDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public ICollection<InvoiceItem>? InvoiceItems { get; set; }
    }
}
