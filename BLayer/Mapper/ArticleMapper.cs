using Core.Interfaces;
using DLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
