using Kodlamaio.Business.Abstracts;
using Kodlamaio.Business.Dtos.Requests;
using Kodlamaio.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kodlamaio.MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory([FromForm] CreateCategoryRequest createCategoryRequest)
        {
            _categoryService.Add(createCategoryRequest);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCategory([FromRoute (Name = "id")] int id)
        {
            var model = _categoryService.GetCategoryUpdate(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory([FromForm] UpdateCategoryRequest updateCategoryRequest)
        {
            _categoryService.Update(updateCategoryRequest);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory([FromRoute(Name = "id")] int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
