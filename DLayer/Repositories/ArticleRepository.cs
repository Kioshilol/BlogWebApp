using Core;
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

        public IEnumerable<Article> Get(bool isPaging, int page)
        {
            if (isPaging)
            {
                var pageSize = AppSettings.GetCountOfPageItems();
                //TODO move init to BLayer
                return _dbContext.Article.Skip((page - 1) * pageSize).Take(pageSize).Include(c => c.Category).Include(at => at.ArticleTags).ThenInclude(t => t.Tag);
            }
            else
                return _dbContext.Article.Include(p => p.Category);
        }

        public Article GetById(int id)
        {
            //TODO move init to BLayer
            return _dbContext.Article.Where(a => a.Id == id).Include(p => p.Category).Include(at => at.ArticleTags).ThenInclude(t => t.Tag).First();
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
