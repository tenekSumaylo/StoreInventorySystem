using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Key]
        public int CategoryId { get; set; }
        
        [Required]
        public string ProductName { get; set; } = string.Empty;

        public Category? Category { get; set; }

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get;set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public ICollection<ProductTag>? Tags { get; set; } 
    }
}
