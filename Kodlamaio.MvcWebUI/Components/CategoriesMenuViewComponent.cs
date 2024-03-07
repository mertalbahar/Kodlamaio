using Kodlamaio.Business.Abstracts;
using Kodlamaio.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kodlamaio.MvcWebUI.Components;

public class CategoriesMenuViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoriesMenuViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke()
    {
        var model = new CategoryListViewModel
        {
            Categories = _categoryService.GetAll()
        };

        return View(model);
    }
}
