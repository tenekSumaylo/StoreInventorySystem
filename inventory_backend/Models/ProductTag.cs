using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class ProductTag : Entity
    {
        public string Tag { get; set; } = string.Empty;
        public Product? Product { get; set; }
    }
}
