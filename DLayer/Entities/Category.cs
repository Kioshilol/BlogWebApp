﻿using System.Collections.Generic;

namespace DLayer.Entities
{
    public partial class Category
    {
        public Category()
        {
            Article = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
