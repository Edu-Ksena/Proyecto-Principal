using Microsoft.AspNetCore.Mvc;
using mi_proyecto.Models;
using mi_proyecto.Services;

namespace mi_proyecto.Controllers
{
    public class SettingsController : Controller
    {
        private readonly DataService _dataService;

        public SettingsController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Settings
        public IActionResult Index()
        {
            var settings = _dataService.GetSettings();
            return View(settings);
        }

        // POST: /Settings/UpdateSchool
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSchool(SystemSettings settings)
        {
            var current = _dataService.GetSettings();
            current.SchoolName = settings.SchoolName;
            current.Address = settings.Address;
            current.Phone = settings.Phone;
            current.SchoolEmail = settings.SchoolEmail;

            _dataService.UpdateSettings(current);
            TempData["SuccessMessage"] = "Ajustes del colegio guardados correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // POST: /Settings/UpdateAdmin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAdmin(SystemSettings settings)
        {
            var current = _dataService.GetSettings();
            current.AdminName = settings.AdminName;
            current.AdminEmail = settings.AdminEmail;

            if (!string.IsNullOrEmpty(settings.NewPassword))
            {
                current.NewPassword = settings.NewPassword;
                current.ConfirmPassword = settings.ConfirmPassword;
            }

            _dataService.UpdateSettings(current);
            TempData["SuccessMessage"] = "Cuenta de administrador actualizada correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}
