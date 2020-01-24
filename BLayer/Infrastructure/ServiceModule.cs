using BLayer.DTO;
using BLayer.Services;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLayer.Infrastructure
{
    public static class ServiceModule
    {
        public static void AddServiceModule(this IServiceCollection services)
        {
            services.AddTransient<IService<ArticleDTO>, ArticleService>();
            services.AddTransient<IService<TagDTO>, TagService>();
            services.AddTransient<IService<CategoryDTO>, CategoryService>();
        }
    }
}
