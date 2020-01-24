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
    public class TagRepository : IRepository<Tag>
    {
        private BlogWebAppContext _dbContext;

        public TagRepository(BlogWebAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var targetCategory = _dbContext.Category.Find(id);
            _dbContext.Remove(targetCategory);
            _dbContext.SaveChanges();
        }

        public void Edit(Tag entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<Tag> Get(bool isPaging, int page)
        {
            if (isPaging)
            {
                var pageSize = AppSettings.GetCountOfPageItems();
                return _dbContext.Tag.Skip((page - 1) * pageSize).Take(pageSize);
            }
            else
                return _dbContext.Tag;
        }

        public Tag GetById(int id)
        {
            return _dbContext.Tag.Find(id);
        }

        public int Insert(Tag entity)
        {
            _dbContext.Tag.Add(entity);
            _dbContext.SaveChanges();
            _dbContext.Entry(entity).GetDatabaseValues();
            return entity.Id;
        }
    }
}
