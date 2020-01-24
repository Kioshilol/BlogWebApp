using BLayer.DTO;
using Core;
using Core.Interfaces;
using DLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BLayer.Services
{
    public class TagService : IService<TagDTO>
    {
        private IUnitOfWork _dataBase;
        private IMapper<Tag, TagDTO> _tagMapper;
        private ILogger<TagService> _logger;
        public TagService(IUnitOfWork dataBase, IMapper<Tag, TagDTO> tagMapper)
        {
            _dataBase = dataBase;
            _tagMapper = tagMapper;
        }

        public int Add(TagDTO tagDTO)
        {
            int id;

            try
            {
                id = _dataBase.Tags.Insert(_tagMapper.Map(tagDTO));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return id;
        }

        public void Edit(TagDTO tagDTO)
        {

            try
            {
                _dataBase.Tags.Edit(_tagMapper.Map(tagDTO));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }
        }


        public TagDTO GetById(int id)
        {
            TagDTO tagDTO;

            try
            {
                tagDTO = _tagMapper.Map(_dataBase.Tags.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return tagDTO;
        }

        public void Delete(int id)
        {
            try
            {
                _dataBase.Tags.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }
        }

        public IEnumerable<TagDTO> Get(bool isPaging, int page)
        {
            IEnumerable<TagDTO> tagDTOs;

            try
            {
                tagDTOs = BaseMapper.Map(_tagMapper, _dataBase.Tags.Get(isPaging, page));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, "Stopped program because of exception");
                throw;
            }

            return tagDTOs;
        }
    }
}
