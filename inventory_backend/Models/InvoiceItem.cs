using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventory_backend.Models
{
    public class InvoiceItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int InvoiceId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice? Invoice { get; set; } 
    }
}
