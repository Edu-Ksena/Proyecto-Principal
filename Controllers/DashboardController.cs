using Microsoft.AspNetCore.Mvc;

namespace EduK.Controllers;

public class DashboardController : Controller
{
    public IActionResult Admin()
    {
        return View();
    }

    public IActionResult Estudiante()
    {
        return View();
    }

    public IActionResult Profesor()
    {
        return View();
    }
}
