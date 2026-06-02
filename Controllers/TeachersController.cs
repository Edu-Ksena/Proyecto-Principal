using Microsoft.AspNetCore.Mvc;
using mi_proyecto.Models;
using mi_proyecto.Services;

namespace mi_proyecto.Controllers
{
    public class TeachersController : Controller
    {
        private readonly DataService _dataService;

        public TeachersController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Teachers
        public IActionResult Index(string searchString)
        {
            var teachers = _dataService.GetTeachers();

            if (!string.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(t => 
                    t.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
                    t.Subject.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewData["CurrentFilter"] = searchString;
            return View(teachers);
        }

        // POST: /Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Subject,Phone")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _dataService.AddTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View("Index", _dataService.GetTeachers());
        }

        // POST: /Teachers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Subject,Phone")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataService.UpdateTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View("Index", _dataService.GetTeachers());
        }

        // POST: /Teachers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _dataService.DeleteTeacher(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
