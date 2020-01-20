using Core;
using DLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLayer.Infrastructure
{
    public static class DbContextModule
    {
        public static void AddDbContextService(this IServiceCollection services)
        {
            services.AddDbContext<BlogWebAppContext>(options => options.UseSqlServer(AppSettings.GetConnectionString()));
        }
    }
}
