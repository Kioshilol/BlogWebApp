using Core.Interfaces;
using DLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLayer.Repositories
{
    public class Article : IRepository<Article>
    {
        private BlogWebAppContext _dbContext;

        public Article(BlogWebAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var targetArticle = _dbContext.Article.Find(id);
            _dbContext.Remove(targetArticle);
            _dbContext.SaveChanges();
        }

        public void Edit(Article entity)
        {

        }

        public IEnumerable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public Article GetById(int id)
        {
            return _dbContext.Article.Find(id);
        }

        public int Insert(Article entity)
        {
            throw new NotImplementedException();
        }
    }
}
