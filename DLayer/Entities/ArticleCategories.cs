using System;
using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class ArticleCategories
    {
        public int CategoryId { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }
    }
}
