using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.TagsRepository
{
    public class TagsRepository : GenericRepository<Tags>, ITagsRepository
    {
        public TagsRepository(InventorySystemDbContext context) : base(context) { }
    }
}
