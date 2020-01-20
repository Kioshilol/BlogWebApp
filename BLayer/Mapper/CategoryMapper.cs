using Core.Interfaces;
using DLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLayer.Mapper
{
    public class CategoryMapper : MapperConfiguration, IMapper<Category, CategoryDTO>
    {
        public CategoryDTO Map(Category category)
        {
            return GetConfiguration().Map<Category, CategoryDTO>(category);
        }

        public Category Map(CategoryDTO categoryDTO)
        {
            return GetConfiguration().Map<CategoryDTO, Category>(categoryDTO;
        }
    }
}
