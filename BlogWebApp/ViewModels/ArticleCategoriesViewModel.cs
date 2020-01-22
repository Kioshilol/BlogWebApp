namespace BLayer.DTO
{
    public partial class ArticleCategoriesViewModel
    {
        public int CategoryId { get; set; }
        public int ArticleId { get; set; }

        public virtual ArticleViewModel Article { get; set; }
        public virtual CategoryViewModel Category { get; set; }
    }
}
