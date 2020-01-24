using BLayer.DTO;
using Core;
using Core.Interfaces;
using DLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BLayer.Services
{
    public class ArticleService : IService<ArticleDTO>
    {
        private IUnitOfWork _dataBase;
        private IMapper<Article, ArticleDTO> _articleMapper;
        private ILogger<ArticleService> _logger;
        public ArticleService(IUnitOfWork dataBase, IMapper<Article, ArticleDTO> articleMapper)
        {
            _dataBase = dataBase;
            _articleMapper = articleMapper;
        }

        public int Add(ArticleDTO articleDTO)
        {
            int id;

            try
            {
                id = _dataBase.Articles.Insert(_articleMapper.Map(articleDTO));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return id;
        }

        public void Edit(ArticleDTO articleDTO)
        {
            try
            {
                _dataBase.Articles.Edit(_articleMapper.Map(articleDTO));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }
        }

        public ArticleDTO GetById(int id)
        {
            ArticleDTO articleDTO;

            try
            {
                articleDTO = _articleMapper.Map(_dataBase.Articles.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return articleDTO;
        }

        public void Delete(int id)
        {
            try
            {
                _dataBase.Articles.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }
        }

        public IEnumerable<ArticleDTO> Get(bool isPaging, int page)
        {
            IEnumerable<ArticleDTO> articlesDTOs;

            try
            {
                articlesDTOs = BaseMapper.Map(_articleMapper, _dataBase.Articles.Get(isPaging, page));
            }

            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return articlesDTOs;
        }
    }
}
