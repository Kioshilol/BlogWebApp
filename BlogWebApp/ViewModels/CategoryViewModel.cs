using System;
using System.Collections.Generic;

namespace BLayer.DTO
{
    public partial class CategoryViewModel
    {
        public CategoryViewModel()
        {
            ArticleCategories = new HashSet<ArticleCategoriesViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleCategoriesViewModel> ArticleCategories { get; set; }
    }
}
