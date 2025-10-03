using inventory_backend.Dtos;

namespace inventory_backend.Services.Tags
{
    public interface ITagService
    {
        Task<IEnumerable<TagResponseDto>> GetTags();
    }
}
