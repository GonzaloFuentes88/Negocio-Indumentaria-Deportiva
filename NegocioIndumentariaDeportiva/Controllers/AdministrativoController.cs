using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBL.Models;

namespace NegocioIndumentariaDeportiva.Controllers
{
    public class AdministrativoController : Controller
    {
        // GET: Administrativo
        
        private Empresa empresa = Empresa.GetInstance;
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult BuscarProducto(long IdProducto)
        {


            return View("");

        }




        public ActionResult EditarProducto(long IdProducto)
        {
            Producto producto = empresa.ObtenerProducto(long IdProducto);

            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Vertodos");
        }





    }
}