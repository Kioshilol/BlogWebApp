using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLayer.DTO
{
    public partial class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Article = new HashSet<ArticleViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleViewModel> Article { get; set; }

    }
}
