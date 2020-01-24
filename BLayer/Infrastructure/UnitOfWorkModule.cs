using Core.Interfaces;
using DLayer;
using Microsoft.Extensions.DependencyInjection;
using Ninject.Modules;

namespace BLayer.Infrastructure
{
    public static class UnitOfWorkModule
    {
        public static void AddUnitOFWorkModule(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
