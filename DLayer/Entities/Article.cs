using System;
using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class Article
    {
        public Article()
        {
            ArticleCategories = new HashSet<ArticleCategories>();
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ArticleCategories> ArticleCategories { get; set; }
        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
