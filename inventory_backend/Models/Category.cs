using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Category : Entity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }
    }
}
