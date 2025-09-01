using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class ProductTag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Tag { get; set; } = string.Empty;
        
        public Product? Product { get; set; }
    }
}
