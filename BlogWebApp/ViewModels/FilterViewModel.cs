using BLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogWebApp.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<ArticleViewModel> articles, int? category)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            articles.Insert(0, new ArticleViewModel { Name = "Все", Id = 0 });
            Categories = new SelectList(articles, "Id", "Name", category);
            SelectedCategory = category.Value;
        }
        public SelectList Categories { get; private set; }
        public int SelectedCategory { get; private set; }
    }
}
