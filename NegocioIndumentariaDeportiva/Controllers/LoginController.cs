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
                if(usuario.Role.IdRole == 1) {
                    return RedirectToAction("Index", "AdminSistema");
                }
                else if (usuario.Role.IdRole == 2)
                {
                    return RedirectToAction("Index", "Gerente");
                }
                else if (usuario.Role.IdRole == 3)
                {
                    return RedirectToAction("Index", "Vendedor");
                }
                else if (usuario.Role.IdRole == 4)
                {
                    return RedirectToAction("Index", "Administrativo");
                }
                else
                {
                    return View("Index", sesion);
                }
            }

            else
            {
                // El usuario no existe o las credenciales son incorrectas
                ModelState.AddModelError("", "Usuario o contraseña inválidos");
                return View("Index", sesion); // Devuelve la vista original con el modelo y el mensaje de error
            }
        }
    }
}