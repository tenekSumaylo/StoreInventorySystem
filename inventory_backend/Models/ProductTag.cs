using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class ProductTag : Entity
    {
        public Tags? Tag { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
