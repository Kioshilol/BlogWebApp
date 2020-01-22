using BLayer.DTO;
using Core.Interfaces;
using DLayer.Entities;

namespace BLayer.Mapper
{
    public class ArticleMapper : MapperConfiguration, IMapper<Article, ArticleDTO>
    {
        public ArticleDTO Map(Article article)
        {
            return GetConfiguration().Map<Article, ArticleDTO>(article);
        }

        public Article Map(ArticleDTO articleDTO)
        {
            return GetConfiguration().Map<ArticleDTO, Article>(articleDTO);
        }
    }
}
