using Kodlamaio.Business.Abstracts;
using Kodlamaio.Business.Dtos.Requests;
using Kodlamaio.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kodlamaio.MvcWebUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var model = new CourseListViewModel
            {
                Courses = _courseService.GetAll()
            };

            return View(model);
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse([FromForm] CreateCourseRequest createCourseRequest)
        {
            _courseService.Add(createCourseRequest);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCourse([FromRoute(Name ="id")] int id)
        {
            var model = _courseService.GetCourseUpdate(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCourse([FromForm] UpdateCourseRequest updateCourseRequest)
        {
            _courseService.Update(updateCourseRequest);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCourse([FromRoute (Name = "id")] int id)
        {
            _courseService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetCourseByCategory([FromRoute (Name = "id")] int categoryId)
        {
            var model = new CourseListViewModel
            {
                Courses = _courseService.GetCourseByCategory(categoryId)
            };

            return View(model);
        }

        public IActionResult GetCourseByInstructor([FromRoute(Name = "id")] int instructorId)
        {
            var model = new CourseListViewModel
            {
                Courses = _courseService.GetCourseByInstructor(instructorId)
            };

            return View(model);
        }
    }
}
