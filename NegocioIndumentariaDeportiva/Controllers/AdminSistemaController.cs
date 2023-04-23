using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrabajoPráctico.Models;

namespace TrabajoPráctico.Controllers
{
    public class AdminSistemaController : Controller
    {
        private readonly ILogger<AdminSistemaController> _logger;

        public AdminSistemaController(ILogger<AdminSistemaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vertodos()
        {
            return View();
        }

        public IActionResult Alta()
        {
            return View();
        }

        public IActionResult Pendientes()
        {
            return View();
        }

        public IActionResult Historial()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}