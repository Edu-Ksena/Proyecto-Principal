using Microsoft.AspNetCore.Mvc;

namespace EduK.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Nosotros()
    {
        return View();
    }

    public IActionResult Soporte()
    {
        return View();
    }
}
