using Microsoft.AspNetCore.Mvc;

namespace mi_proyecto.Controllers
{
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
}
