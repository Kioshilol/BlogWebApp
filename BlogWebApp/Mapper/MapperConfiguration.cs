using AutoMapper;
using BLayer.DTO;

namespace BlogWebApp.Mapper
{
    public abstract class MapperConfiguration
    {
        protected IMapper GetConfiguration()
        {
            var config = new AutoMapper.MapperConfiguration(cfg => {
                cfg.CreateMap<ArticleViewModel, ArticleDTO>().ForMember(dest =>
                dest.ArticleTags, act => act.MapFrom(src => src.ArticleTags));

                cfg.CreateMap<ArticleDTO, ArticleViewModel>().ForMember(dest =>
                dest.ArticleTags, act => act.MapFrom(src => src.ArticleTags));

                cfg.CreateMap<TagViewModel, TagDTO>().ForMember(dest =>
                dest.ArticleTags, act => act.MapFrom(src => src.ArticleTags));

                cfg.CreateMap<TagDTO, TagViewModel>().ForMember(dest =>
                dest.ArticleTags, act => act.MapFrom(src => src.ArticleTags));

                cfg.CreateMap<CategoryViewModel, CategoryDTO>();

                cfg.CreateMap<CategoryDTO, CategoryViewModel>();

                cfg.CreateMap<ArticleTagsDTO, ArticleTagsViewModel>();
                cfg.CreateMap<ArticleTagsViewModel, ArticleTagsDTO>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper;
        }
    }
}
