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
            return RedirectToAction("Vertodos");
        }

        [HttpGet]
        public ActionResult Vertodos()
        {

            List<Producto> productos = empresa.ObtenerProductos();
            return View(productos);
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

        

        [HttpGet]
        public ActionResult EditarProducto(long id)
        {
            Producto producto = empresa.ObtenerProducto(id);

            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Vertodos");

        }





    }
}