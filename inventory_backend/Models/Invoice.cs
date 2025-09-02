using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Key]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalAmount { get; set; }

        [Required]
        public DateOnly InvoiceDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public ICollection<InvoiceItem>? InvoiceItems { get; set; }
    }
}
