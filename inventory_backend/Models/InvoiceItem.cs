using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventory_backend.Models
{
    public class InvoiceItem : Entity
    {

        [Required]
        public Guid InvoiceId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice? Invoice { get; set; } 
    }
}
