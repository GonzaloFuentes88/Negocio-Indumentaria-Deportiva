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

        public ActionResult ComboboxRol()
        {
            Role admin = new Role(1, "Administrador");
            Role vendedor = new Role(2, "Vendedor");
            Role gerente = new Role(3, "Gerente");


            List<Role> roles = new List<Role>();
            roles.Add(admin);
            roles.Add(vendedor);
            roles.Add(gerente);

            ViewBag.roles = new SelectList(roles);

            return View();
;        }


        [HttpPost]

        //
        public ActionResult DarAlta(Empleado empleado, Role rol)
        {
            Usuario usuario = new Usuario();
            usuario.CrearUsuario(empleado, rol);

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