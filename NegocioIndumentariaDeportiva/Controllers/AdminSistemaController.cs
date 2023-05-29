using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBL.Models;



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
        private Empresa empresa = Empresa.GetInstance;

        [HttpGet]
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
            List<Role> roles = new List<Role>();
            roles = empresa.ObtenerRoles();
            ViewBag.roles = roles;
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

        


        [HttpPost]
        public ActionResult DarAlta(Usuario usuario)
        {
            Boolean registrado = empresa.RegistrarUsuario(usuario); 
            if (registrado)
            {

                return View("Alta");

            }
            else
            {
                // El modelo no es válido, manejar los errores de validación
                ModelState.AddModelError("", "Usuario o contraseña inválidos");
                return View("Alta");
            }
;
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