using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLayer.DTO
{
    public partial class ArticleViewModel
    {
        public ArticleViewModel()
        {
            ArticleTags = new HashSet<ArticleTagsViewModel>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }

        public virtual CategoryViewModel Category { get; set; }
        public virtual ICollection<ArticleTagsViewModel> ArticleTags { get; set; }
    }
}
