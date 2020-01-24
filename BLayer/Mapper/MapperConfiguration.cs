using AutoMapper;
using DLayer.Entities;
using BLayer.DTO;

namespace BLayer.Mapper
{
    public abstract class MapperConfiguration
    {
        protected IMapper GetConfiguration()
        {
            var config = new AutoMapper.MapperConfiguration(cfg => {
                cfg.CreateMap<ArticleDTO, Article>().ForMember(dest => 
                dest.ArticleTags, act => act.MapFrom(src => src.ArticleTags));

                cfg.CreateMap<Article, ArticleDTO>().ForMember(dest =>
                dest.ArticleTags, act => act.MapFrom(src => src.ArticleTags));

                cfg.CreateMap<TagDTO, Tag>().ForMember(dest =>
                dest.ArticleTags, act => act.MapFrom(src => src.ArticleTags));

                cfg.CreateMap<Tag, TagDTO>().ForMember(dest =>
                dest.ArticleTags, act => act.MapFrom(src => src.ArticleTags));

                cfg.CreateMap<CategoryDTO, Category>();

                cfg.CreateMap<Category, CategoryDTO>();

                cfg.CreateMap<ArticleTags, ArticleTagsDTO>();
                cfg.CreateMap<ArticleTagsDTO, ArticleTags>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper;
        }
    }
}
