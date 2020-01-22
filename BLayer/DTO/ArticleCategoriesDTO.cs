namespace BLayer.DTO
{
    public partial class ArticleCategoriesDTO
    {
        public int CategoryId { get; set; }
        public int ArticleId { get; set; }

        public virtual ArticleDTO Article { get; set; }
        public virtual CategoryDTO Category { get; set; }
    }
}
