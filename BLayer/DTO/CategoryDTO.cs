using System;
using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class CategoryDTO
    {
        public CategoryDTO()
        {
            ArticleCategories = new HashSet<ArticleCategoriesDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleCategoriesDTO> ArticleCategories { get; set; }
    }
}
