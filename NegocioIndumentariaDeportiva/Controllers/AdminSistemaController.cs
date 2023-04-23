using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NegocioIndumentariaDeportiva.Controllers
{
    public class AdminSistemaController : Controller
    {
        /*
        private readonly ILogger<AdminSistemaController> _logger;

        public AdminSistemaController(ILogger<AdminSistemaController> logger)
        {
            _logger = logger;
        }
        */
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vertodos()
        {
            return View();
        }

        public ActionResult Alta()
        {
            return View();
        }

        public ActionResult Pendientes()
        {
            return View();
        }

        public ActionResult Historial()
        {
            return View();
        }

        /*
         * ARREGLAR ESTA PARTE
         * 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } */
    }
}