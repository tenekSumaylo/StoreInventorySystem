namespace inventory_backend.Models
{
    public class Tags : Entity
    {
        public string Tag { get; set; } = string.Empty;
        public ICollection<ProductTag>? ProductTags { get; set; }

    }
}
