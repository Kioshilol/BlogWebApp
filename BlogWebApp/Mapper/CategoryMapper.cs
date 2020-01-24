using BLayer.DTO;
using Core.Interfaces;

namespace BlogWebApp.Mapper
{
    public class CategoryMapper : MapperConfiguration, IMapper<CategoryDTO, CategoryViewModel>
    {
        public CategoryViewModel Map(CategoryDTO categoryDTO)
        {
            return GetConfiguration().Map<CategoryDTO, CategoryViewModel>(categoryDTO);
        }

        public CategoryDTO Map(CategoryViewModel categoryViewModel)
        {
            return GetConfiguration().Map<CategoryViewModel, CategoryDTO>(categoryViewModel);
        }
    }
}
