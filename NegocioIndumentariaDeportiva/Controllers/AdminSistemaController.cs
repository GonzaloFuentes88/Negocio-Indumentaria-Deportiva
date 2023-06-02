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
        private Empresa empresa = Empresa.GetInstance;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Vertodos()
        {
            List<Usuario> usuarios = empresa.ObtenerUsuarios();
            return View(usuarios);
        }

        [HttpGet]
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
                return RedirectToAction("Alta");
            }
            else
            {
                // El modelo no es válido, manejar los errores de validación
                ModelState.AddModelError("", "Usuario o contraseña inválidos");
                return RedirectToAction("Alta");
            }
;
        }

        [HttpGet]
        public ActionResult BajaUsuario(long id)
        {
            empresa.bajaUsuario(id);
            return RedirectToAction("Vertodos");
        }
        [HttpGet]
        public ActionResult AltaUsuario(long id)
        {
            empresa.altaUsuario(id);
            return RedirectToAction("Vertodos");
        }

        [HttpGet]
        public ActionResult VerUsuario(long id)
        {
            Usuario usuario = empresa.ObtenerUsuario(id);

            if(usuario != null)
            {
                return View();
            }
            return RedirectToAction("Vertodos");

        }

        

    }
}