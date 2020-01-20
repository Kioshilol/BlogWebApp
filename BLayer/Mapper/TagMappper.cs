using Core.Interfaces;
using DLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLayer.Mapper
{
    public class TagMappper : MapperConfiguration, IMapper<Tag, TagDTO>
    {
        public TagDTO Map(Tag tag)
        {
            return GetConfiguration().Map<Tag, TagDTO>(tag);
        }

        public Tag Map(TagDTO tagDTO)
        {
            return GetConfiguration().Map<TagDTO, Tag>(tagDTO);
        }
    }
}
