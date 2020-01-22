using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogWebApp.Models;
using Core.Interfaces;
using BLayer.DTO;
using System.Collections.Generic;
using System;

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
            List<ArticleViewModel> articleViewModels = new List<ArticleViewModel>();

            try
            {
                var articlesDTO = _articleService.GetAll();
                articleViewModels = new List<ArticleViewModel>();

                foreach (var articleDTO in articlesDTO)
                {
                    articleViewModels.Add(_articleMapper.Map(articleDTO));
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, "Stopped program because of exception");
            }

            return View(articleViewModels);
        }
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                try
                {
                    var articleDTO = _articleService.GetById(id.Value);

                    if (articleDTO != null)
                    {
                        var articleViewModel = _articleMapper.Map(articleDTO);
                        return View(articleViewModel);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Stopped program because of exception");
                    throw;
                }

                return NotFound();
            }
            else
            {
                return View(new ArticleViewModel());
            }
        }

        [HttpPost]
        public IActionResult Edit(ArticleViewModel article)
        {
            if (article.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var articleDTO = _articleMapper.Map(article);
                        _articleService.Edit(articleDTO);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, "Stopped program because of exception");
                        throw;
                    }
                }
                else
                    return View(article);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var articleDTO = _articleMapper.Map(article);
                        _articleService.Add(articleDTO);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, "Stopped program because of exception");
                        throw;
                    }
                }
                else
                    return View(article);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    var articleDTO = _articleService.GetById(id.Value);

                    if (articleDTO != null)
                    {
                        var articleViewModel = _articleMapper.Map(articleDTO);
                        return View(articleViewModel);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Stopped program because of exception");
                    throw;
                }
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            _logger.LogInformation($"{id}");

            if (id != null)
            {
                try
                {
                    _articleService.Delete(id.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Stopped program because of exception");
                    throw;
                }

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    var articleDTO = _articleService.GetById(id.Value);

                    if (articleDTO != null)
                    {
                        var articleViewModel = _articleMapper.Map(articleDTO);
                        return View(articleViewModel);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Stopped program because of exception");
                    throw;
                }
            }

            return NotFound();
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
