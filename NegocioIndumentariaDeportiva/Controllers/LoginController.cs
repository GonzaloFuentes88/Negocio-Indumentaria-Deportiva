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
            Usuario usuario = empresa.IniciarSesion("jorger12", "jorgelinrodriguez12");

            if(usuario != null)
            {
                Console.WriteLine(usuario.ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult Loign()
        {


            //ACA SE MANIPULAN LOS DATOS Y SE VERIFICA SI EL USUARIO EXISTE
            //FIJATE COMO RECIBIR PARAMETRO ATRAVES DE ASP .NET MVC
            //USA EL METODO Empresa.IniciarSesion(string user, string pass)
            //TE VA A DEVOLVER EL USUARIO EN CASO DE EXISTIR EN LA BD
            return RedirectToAction("/Home/Index");
        }
    }
}