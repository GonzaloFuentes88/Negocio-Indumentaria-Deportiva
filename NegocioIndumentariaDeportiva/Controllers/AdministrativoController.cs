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
        public ActionResult BuscarProducto(long idProd)
        {

            Producto producto = empresa.ObtenerProducto(idProd);

            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Vertodos");

        }




        public ActionResult EditarProducto()
        {
            Producto producto = new Producto();
            return View(producto);
        }





    }
}