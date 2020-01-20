using AutoMapper;
using DLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLayer.Mapper
{
    public abstract class MapperConfiguration
    {
        protected IMapper GetConfiguration()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ArticleDTO, Article>();
                cfg.CreateMap<Article, ArticleDTO>();
                cfg.CreateMap<TagDTO, Tag>();
                cfg.CreateMap<Tag, TagDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryDTO>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper;
        }
    }
}
