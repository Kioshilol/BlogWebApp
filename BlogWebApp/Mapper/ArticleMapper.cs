using BLayer.DTO;
using Core.Interfaces;

namespace BlogWebApp.Mapper
{
    public class ArticleMapper : MapperConfiguration, IMapper<ArticleDTO, ArticleViewModel>
    {
        public ArticleDTO Map(ArticleViewModel article)
        {
            return GetConfiguration().Map<ArticleViewModel, ArticleDTO>(article);
        }

        public ArticleViewModel Map(ArticleDTO articleDTO)
        {
            return GetConfiguration().Map<ArticleDTO, ArticleViewModel>(articleDTO);
        }
    }
}
