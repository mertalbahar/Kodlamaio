using Kodlamaio.Business.Abstracts;
using Kodlamaio.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kodlamaio.MvcWebUI.Components;

public class InstructorsMenuViewComponent : ViewComponent
{
    private readonly IInstructorService _instructorService;

    public InstructorsMenuViewComponent(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }

    public IViewComponentResult Invoke()
    {
        var model = new InstructorListViewModel
        {
            Instructors = _instructorService.GetAll()
        };

        return View(model);
    }
}
