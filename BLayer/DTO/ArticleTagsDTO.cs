using System;
using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class ArticleTagsDTO
    {
        public int TagId { get; set; }
        public int ArticleId { get; set; }

        public virtual ArticleDTO Article { get; set; }
        public virtual TagDTO Tag { get; set; }
    }
}
