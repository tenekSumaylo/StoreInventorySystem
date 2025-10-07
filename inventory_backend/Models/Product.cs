using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Models
{
    public class Product : Entity
    {
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; } = string.Empty;

        public Category? Category { get; set; }
        public string Brand { get; set; } = string.Empty;
        public double Price { get;set; }
        public int Stock { get; set; }
        public byte[]? ProductImage { get; set; }
        public ICollection<ProductTag> Tags { get; set; } = new List<ProductTag>();

        // for cart item
        public ICollection<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
