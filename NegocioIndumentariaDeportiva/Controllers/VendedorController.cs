using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBL.Models;

namespace NegocioIndumentariaDeportiva.Controllers
{
    public class VendedorController : Controller
    {
        private Empresa empresa = Empresa.GetInstance;
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult RegistrarVenta()
        {
            Venta venta = new Venta();

            return View(venta);

        }

        [HttpPost]
        public ActionResult hacerVenta(Venta venta, string agregarDetalle, int idProd)
        {
            double total = 0;
            foreach (var detalle in venta.Detalles)
            {
                double subtotal = detalle.Cantidad * detalle.Precio;
                total += subtotal;
            }
            venta.Total = total;
            if (!string.IsNullOrEmpty(agregarDetalle))
            {
                Producto producto = empresa.ObtenerProducto(idProd);
                Detalle detalle = new Detalle();
                detalle.Producto = producto;
                venta.Detalles.Add(detalle);
            }

            // Resto de la lógica para registrar la venta

            return RedirectToAction("Index");
        }





        [HttpPost]
        public ActionResult BuscarProducto(long idProd)
        {
           
 
            return View("RegistrarVenta");

        }






    }
}