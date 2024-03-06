using Kodlamaio.Business.Abstracts;
using Kodlamaio.Business.Dtos.Requests;
using Kodlamaio.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kodlamaio.MvcWebUI.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public IActionResult Index()
        {
            var model = new InstructorListViewModel
            {
                Instructors = _instructorService.GetAll()
            };

            return View(model);
        }

        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInstructor([FromForm] CreateInstructorRequest createInstructorRequest)
        {
            _instructorService.Add(createInstructorRequest);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateInstructor([FromRoute (Name = "id")] int id)
        {
            var model = _instructorService.GetInstructorUpdate(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInstructor([FromForm] UpdateInstructorRequest updateInstructorRequest)
        {
            _instructorService.Update(updateInstructorRequest);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteInstructor([FromRoute(Name = "id")] int id)
        {
            _instructorService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
