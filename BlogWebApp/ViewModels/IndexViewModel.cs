using BLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApp.ViewModels
{
    public class IndexViewModel
    {
        public ICollection<ArticleViewModel> Articles { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; }
        public ICollection<TagViewModel> Tags { get; set; }
    }
}
