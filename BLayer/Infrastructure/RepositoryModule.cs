using BLayer.DTO;
using Core.Interfaces;
using DLayer.Entities;
using DLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BLayer.Infrastructure
{
    public static class RepositoryModule
    {
        public static void AddRepositoryModule(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Article>, ArticleRepository>();
            services.AddTransient<IRepository<Tag>, TagRepository>();
            services.AddTransient<IRepository<Category>, CategoryRepository>();
        }
    }
}
