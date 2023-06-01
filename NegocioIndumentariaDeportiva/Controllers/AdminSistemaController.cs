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
            List<Usuario> usuarios = new List<Usuario>();
            Empleado empleado = new Empleado();
            empleado.Legajo = 123;
            empleado.Nombre = "Pepe";
            empleado.Apellido = "Reo";
            empleado.DNI = 121331;
            empleado.Email = "pepe@gmail.com";
            empleado.Telefono = 123131;
            Role r = new Role(1,"ADMIN");
            Direccion dir = new Direccion(23,"12312","Mitre",123);
            empleado.Direccion = dir;
            Usuario user = new Usuario();
            user.Role = r;
            user.Empleado = empleado;
            user.Username = "Jose";
            user.Password = "123";
            user.Estado = true;
            Usuario user2 = new Usuario();
            user2.Role = r;
            user2.Empleado = empleado;
            user2.Username = "JoseLues";
            user2.Password = "123";
            user2.Estado = false;

            usuarios.Add(user);
            usuarios.Add(user2);
            return View(usuarios);
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