using Core.Interfaces;
using DLayer.Context;
using DLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogWebAppContext _dbContext;
        private IRepository<Article> _articles;
        private IRepository<Tag> _tags;
        private IRepository<Category> _categories;
        private bool disposed = false;

        public UnitOfWork(IRepository<Article> articles, IRepository<Tag> tags, IRepository<Category> categories, BlogWebAppContext dbContext)
        {
            _dbContext = dbContext;
            _articles = articles;
            _tags = tags;
            _categories = categories;
        }

        public IRepository<Article> Articles
        {
            get
            {
                    return _articles;
            }

        }
        public IRepository<Tag> Tags
        {
            get
            {
                return _tags;
            }

        }

        public IRepository<Category> Categories
        {
            get
            {
                return _categories;
            }

        }


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
