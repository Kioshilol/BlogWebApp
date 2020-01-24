using BLayer.DTO;
using Core.Interfaces;

namespace BlogWebApp.Mapper
{
    public class TagMappper : MapperConfiguration, IMapper<TagDTO, TagViewModel>
    {
        public TagViewModel Map(TagDTO tagDTO)
        {
            return GetConfiguration().Map<TagDTO, TagViewModel>(tagDTO);
        }

        public TagDTO Map(TagViewModel tagViewModel)
        {
            return GetConfiguration().Map<TagViewModel, TagDTO>(tagViewModel);
        }
    }
}
