using Microsoft.AspNetCore.Mvc;
using mi_proyecto.Models;
using mi_proyecto.Services;

namespace mi_proyecto.Controllers
{
    public class CoursesController : Controller
    {
        private readonly DataService _dataService;

        public CoursesController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Courses
        public IActionResult Index(string searchString)
        {
            var courses = _dataService.GetCourses();

            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => 
                    c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
                    c.TeacherName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.Teachers = _dataService.GetTeachers();
            ViewData["CurrentFilter"] = searchString;
            return View(courses);
        }

        // POST: /Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,TeacherId,StudentsCount")] Course course)
        {
            if (ModelState.IsValid)
            {
                _dataService.AddCourse(course);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Teachers = _dataService.GetTeachers();
            return View("Index", _dataService.GetCourses());
        }

        // POST: /Courses/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,TeacherId,StudentsCount")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataService.UpdateCourse(course);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Teachers = _dataService.GetTeachers();
            return View("Index", _dataService.GetCourses());
        }

        // POST: /Courses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _dataService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
