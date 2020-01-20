using System;
using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class Category
    {
        public Category()
        {
            ArticleCategories = new HashSet<ArticleCategories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleCategories> ArticleCategories { get; set; }
    }
}
