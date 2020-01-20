using System;
using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class ArticleTags
    {
        public int TagId { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
