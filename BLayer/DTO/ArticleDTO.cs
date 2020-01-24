using System.Collections.Generic;

namespace BLayer.DTO
{
    public partial class ArticleDTO
    {
        public ArticleDTO()
        {
            ArticleTags = new HashSet<ArticleTagsDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }

        public virtual CategoryDTO Category { get; set; }
        public virtual ICollection<ArticleTagsDTO> ArticleTags { get; set; }

    }
}
