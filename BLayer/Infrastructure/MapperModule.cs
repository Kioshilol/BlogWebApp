using BLayer.DTO;
using BLayer.Mapper;
using Core.Interfaces;
using DLayer.Entities;
using DLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ninject.Modules;

namespace BLayer.Infrastructure
{
    public static class MapperModule
    {
        public static void AddBLayerMapperModule(this IServiceCollection services)
        {
            services.AddTransient<IMapper<Article, ArticleDTO>, ArticleMapper>();
            services.AddTransient<IMapper<Category, CategoryDTO>, CategoryMapper>();
            services.AddTransient<IMapper<Tag, TagDTO>, TagMappper>();
        }
    }
}
