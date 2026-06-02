using Microsoft.AspNetCore.Mvc;

namespace mi_proyecto.Controllers
{
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
}
