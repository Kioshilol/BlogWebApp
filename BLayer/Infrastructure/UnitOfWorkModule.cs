using Core.Interfaces;
using DLayer;
using DLayer.Entities;
using DLayer.Repositories;
using Ninject.Modules;

namespace BLayer.Infrastructure
{
    public class UnitOfWorkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
