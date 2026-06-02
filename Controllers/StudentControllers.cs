using Microsoft.AspNetCore.Mvc;

namespace mi_proyecto.Controllers
{
    public class StudentHomeController : Controller
    {
        public IActionResult Index() => View();
    }

    public class AcademicoController : Controller
    {
        public IActionResult Index() => View();
    }

    public class HorarioController : Controller
    {
        public IActionResult Index() => View();
    }

    public class AsistenciaController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Justificar() => View();
    }

    public class EleccionesController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Votar() => View();
        public IActionResult Inscripcion() => View();
        public IActionResult Resultados() => View();
    }

    public class PerfilController : Controller
    {
        public IActionResult Index() => View();
    }
}
