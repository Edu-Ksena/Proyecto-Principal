using Microsoft.AspNetCore.Mvc;
using mi_proyecto.Models;
using mi_proyecto.Services;

namespace mi_proyecto.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DataService _dataService;

        public StudentsController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Students
        public IActionResult Index(string searchString)
        {
            var students = _dataService.GetStudents();

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => 
                    s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
                    s.Grade.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    s.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewData["CurrentFilter"] = searchString;
            return View(students);
        }

        // POST: /Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Grade,Status,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _dataService.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View("Index", _dataService.GetStudents());
        }

        // POST: /Students/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Grade,Status,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataService.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View("Index", _dataService.GetStudents());
        }

        // POST: /Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _dataService.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
