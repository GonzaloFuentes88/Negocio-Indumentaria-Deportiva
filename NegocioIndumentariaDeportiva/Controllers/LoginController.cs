using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBL.Models;

namespace NegocioIndumentariaDeportiva.Controllers
{
    public class LoginController : Controller
    {
        private Empresa empresa = Empresa.GetInstance;
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            //MUESTRA LA VISTA LOGIN
            //ESTO ERA DE PRUEBA PARA VALIDAR QUE SE OBTENIA AL USUARIO
            /**Usuario usuario = empresa.IniciarSesion("jorger12", "jorgelinrodriguez12");

            if(usuario != null)
            {
                Console.WriteLine(usuario.ToString());
            }**/
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario sesion)
        {

            // Llama al metodo inciar seson para verificar las credenciales de usuario
            Usuario usuario = empresa.IniciarSesion(sesion.Username, sesion.Password);

            if (usuario != null)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // El usuario no existe o las credenciales son incorrectas
                ViewBag.ErrorMessage = "Invalid username or password";
                return View(); // Devuelve la vista de nuevo para mostrar el mensaje de error
            }
        }
    }
}