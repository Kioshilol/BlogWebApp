using Core.Interfaces;
using DLayer.Entities;
using DLayer.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLayer.Infrastructure
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Article>>().To<ArticleRepository>();
            Bind<IRepository<Tag>>().To<TagRepository>();
            Bind<IRepository<Category>>().To<CategoryRepository>();
        }
    }
}
