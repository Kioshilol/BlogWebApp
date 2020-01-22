using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogWebApp.Models;
using Core.Interfaces;
using BLayer.DTO;
using System.Collections.Generic;

namespace BlogWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IService<ArticleDTO> _articleService;
        private IMapper<ArticleDTO, ArticleViewModel> _articleMapper;
        public HomeController(ILogger<HomeController> logger, IService<ArticleDTO> articleService,
            IMapper<ArticleDTO, ArticleViewModel> articleMapper)
        {
            _logger = logger;
            _articleService = articleService;
            _articleMapper = articleMapper;
        }

        public IActionResult Index()
        {
            var articlesDTO = _articleService.GetAll();

            var articleViewModels = new List<ArticleViewModel>();

            foreach(var articleDTO in articlesDTO)
            {
                articleViewModels.Add(_articleMapper.Map(articleDTO));
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
