﻿using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
