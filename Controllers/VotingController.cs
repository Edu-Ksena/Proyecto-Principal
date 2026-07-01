using Microsoft.AspNetCore.Mvc;
using mi_proyecto.Models;
using mi_proyecto.Services;
using System.Collections.Generic;

namespace mi_proyecto.Controllers
{
    public class VotingController : Controller
    {
        private readonly DataService _dataService;

        public VotingController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Voting/Index
        // Vista 1: Dashboard de Elecciones
        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard de Elecciones";
            ViewData["SectionTitle"] = "SGA Académico / Votaciones / Dashboard";
            return View();
        }

        // GET: /Voting/Crear
        // Vista 2: Configuración de Proceso Electoral
        public IActionResult Crear()
        {
            ViewData["Title"] = "Nueva Elección";
            ViewData["SectionTitle"] = "Elecciones / Nueva Elección";
            return View();
        }

        // GET: /Voting/Registro
        // Vista 3: Historial de Votaciones
        public IActionResult Registro()
        {
            ViewData["Title"] = "Historial de Votaciones";
            ViewData["SectionTitle"] = "SGA Académico / Votaciones / Registro";
            return View();
        }

        // GET: /Voting/Detalle
        // Vista 4: Detalles y Resultados
        public IActionResult Detalle(string id = "V-24-001")
        {
            ViewData["Title"] = "Resultados";
            ViewData["SectionTitle"] = "SGA Académico / Votaciones / Resultados";
            ViewData["ElectionId"] = id;
            return View();
        }
    }
}
