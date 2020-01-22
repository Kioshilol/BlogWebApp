﻿using BLayer.DTO;
using Core.Interfaces;
using DLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BLayer.Services
{
    public class TagService : BaseService, IService<TagDTO>
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

        public IEnumerable<TagDTO> GetAll()
        {
            IEnumerable<TagDTO> tagDTOs;

            try
            {
                tagDTOs = Map(_tagMapper, _dataBase.Tags.GetAll());
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