using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(0)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }
    }
}
