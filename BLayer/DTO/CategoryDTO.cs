using System.Collections.Generic;

namespace BLayer.DTO
{
    public partial class CategoryDTO
    {
        public CategoryDTO()
        {
            Article = new HashSet<ArticleDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleDTO> Article { get; set; }
    }
}
