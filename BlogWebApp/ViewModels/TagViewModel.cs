using System;
using System.Collections.Generic;

namespace BLayer.DTO
{
    public partial class TagViewModel
    {
        public TagViewModel()
        {
            ArticleTags = new HashSet<ArticleTagsViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleTagsViewModel> ArticleTags { get; set; }
    }
}
