using System;
using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class ArticleDTO
    {
        public ArticleDTO()
        {
            ArticleCategories = new HashSet<ArticleCategoriesDTO>();
            ArticleTags = new HashSet<ArticleTagsDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ArticleCategoriesDTO> ArticleCategories { get; set; }
        public virtual ICollection<ArticleTagsDTO> ArticleTags { get; set; }
    }
}
