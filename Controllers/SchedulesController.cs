using Microsoft.AspNetCore.Mvc;
using mi_proyecto.Models;
using mi_proyecto.Services;

namespace mi_proyecto.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly DataService _dataService;

        public SchedulesController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Schedules
        public IActionResult Index(string filterCourse, string filterTeacher)
        {
            var slots = _dataService.GetScheduleSlots();

            if (!string.IsNullOrEmpty(filterCourse))
            {
                slots = slots.Where(s => s.Grade.Contains(filterCourse, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(filterTeacher))
            {
                slots = slots.Where(s => s.TeacherName.Contains(filterTeacher, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.Courses = _dataService.GetCourses().Select(c => c.Name.Split('-').Last()).Distinct().ToList();
            ViewBag.Teachers = _dataService.GetTeachers().Select(t => t.Name.Split(' ').Last()).Distinct().ToList();
            ViewData["CurrentCourse"] = filterCourse;
            ViewData["CurrentTeacher"] = filterTeacher;

            return View(slots);
        }
    }
}
