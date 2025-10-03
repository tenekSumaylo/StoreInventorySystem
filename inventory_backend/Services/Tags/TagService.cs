using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Repository.TagsRepository;

namespace inventory_backend.Services.Tags
{
    public class TagService(ITagsRepository tagRepo, IMapper mapper) : ITagService
    {
        private readonly ITagsRepository _tagRepository = tagRepo;
        private readonly IMapper _mapper = mapper;
        public async Task<IEnumerable<TagResponseDto>> GetTags()
        {
            return _mapper.Map<IEnumerable<TagResponseDto>>( await _tagRepository.Read());
        }
    }
}
