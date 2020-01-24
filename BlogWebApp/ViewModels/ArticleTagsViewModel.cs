namespace BLayer.DTO
{
    public partial class ArticleTagsViewModel
    {
        public int TagId { get; set; }
        public int ArticleId { get; set; }

        public virtual ArticleViewModel Article { get; set; }
        public virtual TagViewModel Tag { get; set; }
    }
}
