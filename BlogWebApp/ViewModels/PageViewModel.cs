using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApp.ViewModels
{
    public class PageViewModel
    {
        public int TotalPages { get; private set; }

        public PageViewModel(int totalPages)
        {
            TotalPages = totalPages / AppSettings.GetCountOfPageItems();

            if (totalPages % AppSettings.GetCountOfPageItems() != 0)
                TotalPages += 1;
        }
    }
}
