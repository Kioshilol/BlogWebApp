using Core.Interfaces;
using DLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLayer.Repositories
{
    public class ArticleRepository : IRepository<ArticleRepository>
    {
        private BlogWebAppContext _dbContext;

        public ArticleRepository(BlogWebAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            _dbContext.Article.Remove(id);
        }

        public void Edit(ArticleRepository entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleRepository> GetAll()
        {
            throw new NotImplementedException();
        }

        public ArticleRepository GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ArticleRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
