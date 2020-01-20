using Core.Interfaces;
using DLayer.Context;
using DLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLayer.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private BlogWebAppContext _dbContext;

        public ArticleRepository(BlogWebAppContext dbContext)
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
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<Article> GetAll()
        {
            return _dbContext.Article;
        }

        public Article GetById(int id)
        {
            return _dbContext.Article.Find(id);
        }

        public int Insert(Article entity)
        {
            _dbContext.Article.Add(entity);
            _dbContext.SaveChanges();
            _dbContext.Entry(entity).GetDatabaseValues();
            return entity.Id;
        }
    }
}
