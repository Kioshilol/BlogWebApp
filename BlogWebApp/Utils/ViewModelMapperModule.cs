using BLayer.DTO;
using BlogWebApp.Mapper;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlogWebApp.Utils
{
    public static class ViewModelMapperModulee
    {
        public static void AddMapperModule(this IServiceCollection services)
        {
            services.AddTransient<IMapper<ArticleDTO, ArticleViewModel>, ArticleMapper>();
            services.AddTransient<IMapper<CategoryDTO, CategoryViewModel>, CategoryMapper>();
            services.AddTransient<IMapper<TagDTO, TagViewModel>, TagMappper>();
        }
    }
}
