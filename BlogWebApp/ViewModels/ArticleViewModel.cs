using System;
using System.Collections.Generic;

namespace BLayer.DTO
{
    public partial class ArticleViewModel
    {
        public ArticleViewModel()
        {
            ArticleCategories = new HashSet<ArticleCategoriesViewModel>();
            ArticleTags = new HashSet<ArticleTagsViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ArticleCategoriesViewModel> ArticleCategories { get; set; }
        public virtual ICollection<ArticleTagsViewModel> ArticleTags { get; set; }
    }
}
