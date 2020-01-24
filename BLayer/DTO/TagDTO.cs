using System;
using System.Collections.Generic;

namespace BLayer.DTO
{
    public partial class TagDTO
    {
        public TagDTO()
        {
            ArticleTags = new HashSet<ArticleTagsDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleTagsDTO> ArticleTags { get; set; }
    }
}
