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
    public class CategoryRepository : IRepository<Category>
    {
        private BlogWebAppContext _dbContext;

        public CategoryRepository(BlogWebAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var targetCategory = _dbContext.Category.Find(id);
            _dbContext.Remove(targetCategory);
            _dbContext.SaveChanges();
        }

        public void Edit(Category entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> Get(bool isPaging, int page)
        {
            if (isPaging)
            {
                var pageSize = AppSettings.GetCountOfPageItems();
                return _dbContext.Category.Skip((page - 1) * pageSize).Take(pageSize);
            }
            else
                return _dbContext.Category;
        }

        public Category GetById(int id)
        {
            return _dbContext.Category.Find(id);
        }

        public int Insert(Category entity)
        {
            _dbContext.Category.Add(entity);
            _dbContext.SaveChanges();
            _dbContext.Entry(entity).GetDatabaseValues();
            return entity.Id;
        }
    }
}
