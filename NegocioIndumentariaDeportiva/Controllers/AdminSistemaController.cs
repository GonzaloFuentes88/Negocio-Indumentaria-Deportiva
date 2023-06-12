susing System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBL.Models;
using Entitys.Entidades;



namespace NegocioIndumentariaDeportiva.Controllers
{
    public class AdminSistemaController : Controller
    {
        private NegocioUsuario gestorUsuarios = new NegocioUsuario();
        private NegocioRole gestorRoles = new NegocioRole();
        private Empresa empresa = Empresa.GetInstance;

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Vertodos");
        }

        [HttpGet]
        public ActionResult Vertodos()
        {
            List<Usuario> usuarios = gestorUsuarios.ObtenerUsuarios();
            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Alta()
        {
            List<Role> roles = new List<Role>();
            roles = gestorRoles.ObtenerRoles();
            ViewBag.roles = roles;
            return View();
        }


        [HttpPost]
        public ActionResult DarAlta(Usuario usuario)
        {
            if(usuario.IdUsuario == 0)
            {
                bool registrado = gestorUsuarios.RegistrarUsuario(usuario);
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
            }
            else
            {
                bool editado = gestorUsuarios.EditarUsuario(usuario);
                return RedirectToAction("Vertodos");
            }

        }

        [HttpGet]
        public ActionResult BajaUsuario(long id)
        {
            gestorUsuarios.bajaUsuario(id);
            return RedirectToAction("Vertodos");
        }
        [HttpGet]
        public ActionResult AltaUsuario(long id)
        {
            gestorUsuarios.altaUsuario(id);
            return RedirectToAction("Vertodos");
        }

        [HttpGet]
        public ActionResult VerUsuario(long id)
        {
            Usuario usuario = gestorUsuarios.ObtenerUsuario(id);

            if(usuario != null)
            {
                return View(usuario);
            }
            return RedirectToAction("Vertodos");

        }

        [HttpGet]
        public ActionResult EditarUsuario(long id)
        {
            Usuario usuario = gestorUsuarios.ObtenerUsuario(id);
            List<Role> roles = new List<Role>();
            roles = gestorRoles.ObtenerRoles();
            ViewBag.roles = roles;

            if (usuario != null)
            {
                return View(usuario);
            }
            return RedirectToAction("Vertodos");
        }

        public ActionResult Salir()
        {
            empresa.UsuarioEnUso = null;
            return RedirectToAction("Index","Login");
        }

        

    }
}