using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mi_proyecto.Models;
using mi_proyecto.Services;

namespace mi_proyecto.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly ILogger<AdminHomeController> _logger;
        private readonly DataService _dataService;

        public AdminHomeController(ILogger<AdminHomeController> logger, DataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            var settings = _dataService.GetSettings();
            ViewData["SchoolName"] = settings.SchoolName;
            ViewData["AdminName"] = settings.AdminName;

            var model = new DashboardViewModel
            {
                TotalStudents = _dataService.GetStudents().Count + 1392,
                TotalTeachers = _dataService.GetTeachers().Count + 26,
                ActiveCoursesCount = _dataService.GetCourses().Count + 12,
                ActiveSchedulesCount = 18,
                TodayClasses = _dataService.GetScheduleSlots().Where(s => s.Day == "Lunes").ToList()
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
