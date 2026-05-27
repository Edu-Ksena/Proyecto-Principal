using Microsoft.AspNetCore.Mvc;

namespace EduK.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Registro()
    {
        return View();
    }

    public IActionResult Recuperacion()
    {
        return View();
    }
}
