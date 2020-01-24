using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogWebApp.Models;
using Core.Interfaces;
using BLayer.DTO;
using System;
using System.Linq;
using BlogWebApp.ViewModels;
using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BlogWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IService<ArticleDTO> _articleService;
        private IService<CategoryDTO> _categoryService;
        private IService<TagDTO> _tagService;
        private IMapper<ArticleDTO, ArticleViewModel> _articleMapper;
        private IMapper<CategoryDTO, CategoryViewModel> _categoryMapper;
        private IMapper<TagDTO, TagViewModel> _tagMapper;

        public HomeController(ILogger<HomeController> logger, IService<ArticleDTO> articleService, IService<CategoryDTO> categoryService, IService<TagDTO> tagService,
            IMapper<ArticleDTO, ArticleViewModel> articleMapper, IMapper<CategoryDTO, CategoryViewModel> categoryMapper, IMapper<TagDTO, TagViewModel> tagMapper)
        {
            _logger = logger;
            _articleService = articleService;
            _categoryService = categoryService;
            _tagService = tagService;
            _articleMapper = articleMapper;
            _categoryMapper = categoryMapper;
            _tagMapper = tagMapper;
        }

        public IActionResult Index(int page = 1)
        {
            var indexViewModel = new IndexViewModel();

            try
            {
                //TODO make another way to get pagination and all entities
                indexViewModel.Articles = BaseMapper.MapViewModel(_articleMapper, _articleService.Get(true, page));
                indexViewModel.Categories = BaseMapper.MapViewModel(_categoryMapper, _categoryService.Get(false, page));
                indexViewModel.Tags = BaseMapper.MapViewModel(_tagMapper, _tagService.Get(false, page));

                indexViewModel.PageViewModel = new PageViewModel(_articleService.Get(false, 1).Count());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, "Stopped program because of exception");
            }

            //var filtredArticles = articleViewModels.Where(p => p.ArticleCategories.Any(m => m.CategoryId == 2));

            return View(indexViewModel);
        }
        public IActionResult Edit(int? id)
        {
            var categories = BaseMapper.MapViewModel(_categoryMapper, _categoryService.Get(false, 0));
            var categoriesSelectedList = new SelectList(categories.ToList(), "Id", "Name");
            ViewBag.Categories = categoriesSelectedList;

            var tags = BaseMapper.MapViewModel(_tagMapper, _tagService.Get(false, 0));
            ViewBag.Tags = tags;

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
        public IActionResult Edit(ArticleViewModel article, int[] selectedTags)
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
                        foreach (var id in selectedTags)
                        {
                            article.ArticleTags.Add(new ArticleTagsViewModel { TagId = id });
                        }
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
                {
                    return View(article);
                }
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

        #region Category CRUD

        public IActionResult EditCategory(int? id)
        {
            if (id.HasValue)
            {
                try
                {
                    var categoryDTO = _categoryService.GetById(id.Value);

                    if (categoryDTO != null)
                    {
                        var categoryViewModel = _categoryMapper.Map(categoryDTO);
                        return View(categoryViewModel);
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
                return View(new CategoryViewModel());
            }
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryViewModel category)
        {
            if (category.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var categoryDTO = _categoryMapper.Map(category);
                        _categoryService.Edit(categoryDTO);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, "Stopped program because of exception");
                        throw;
                    }
                }
                else
                    return View(category);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var categoryDTO = _categoryMapper.Map(category);
                        _categoryService.Add(categoryDTO);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, "Stopped program because of exception");
                        throw;
                    }
                }
                else
                    return View(category);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id != null)
            {
                try
                {
                    var categoryDTO = _categoryService.GetById(id.Value);

                    if (categoryDTO != null)
                    {
                        var categoryViewModel = _categoryMapper.Map(categoryDTO);
                        return View(categoryViewModel);
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

        [HttpPost, ActionName("DeleteCategory")]
        public IActionResult DeleteCategoryConfirmed(int? id)
        {
            _logger.LogInformation($"{id}");

            if (id != null)
            {
                try
                {
                    _categoryService.Delete(id.Value);
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

        #endregion

        #region Tag CRUD
        public IActionResult EditTag(int? id)
        {
            if (id.HasValue)
            {
                try
                {
                    var tagDTO = _tagService.GetById(id.Value);

                    if (tagDTO != null)
                    {
                        var tagViewModel = _tagMapper.Map(tagDTO);
                        return View(tagViewModel);
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
                return View(new TagViewModel());
            }
        }

        [HttpPost]
        public IActionResult EditTag(TagViewModel tag)
        {
            if (tag.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var tagDTO = _tagMapper.Map(tag);
                        _tagService.Edit(tagDTO);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, "Stopped program because of exception");
                        throw;
                    }
                }
                else
                    return View(tag);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var tagDTO = _tagMapper.Map(tag);
                        _tagService.Add(tagDTO);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, "Stopped program because of exception");
                        throw;
                    }
                }
                else
                    return View(tag);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTag(int? id)
        {
            if (id != null)
            {
                try
                {
                    var tagDTO = _tagService.GetById(id.Value);

                    if (tagDTO != null)
                    {
                        var tagViewModel = _tagMapper.Map(tagDTO);
                        return View(tagViewModel);
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

        [HttpPost, ActionName("DeleteTag")]
        public IActionResult DeleteTagConfirmed(int? id)
        {
            _logger.LogInformation($"{id}");

            if (id != null)
            {
                try
                {
                    _tagService.Delete(id.Value);
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
#endregion

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
