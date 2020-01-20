using DLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Article> Articles { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Category> Categories { get; }
        void Save();
        void Dispose();
    }
}
