using BLayer.DTO;
using Core.Interfaces;
using DLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BLayer.Services
{
    public class CategoryService : BaseService, IService<CategoryDTO>
    {
        private IUnitOfWork _dataBase;
        private IMapper<Category, CategoryDTO> _categoryMapper;
        private ILogger<CategoryService> _logger;
        public CategoryService(IUnitOfWork dataBase, IMapper<Category, CategoryDTO> categoryMapper)
        {
            _dataBase = dataBase;
            _categoryMapper = categoryMapper;
        }

        public int Add(CategoryDTO categoryDTO)
        {
            int id;

            try
            {
                id = _dataBase.Categories.Insert(_categoryMapper.Map(categoryDTO));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return id;
        }

        public void Edit(CategoryDTO categoryDTO)
        {
            try
            {
                _dataBase.Categories.Edit(_categoryMapper.Map(categoryDTO));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }
        }

        public CategoryDTO GetById(int id)
        {
            CategoryDTO categoryDTO;

            try
            {
                categoryDTO = _categoryMapper.Map(_dataBase.Categories.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return categoryDTO;
        }

        public void Delete(int id)
        {
            try
            {
                _dataBase.Categories.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            IEnumerable<CategoryDTO> categoryDTOs;

            try
            {
                categoryDTOs = Map(_categoryMapper, _dataBase.Categories.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return categoryDTOs;
        }
    }
}
