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
        Venta venta = new Venta();
        List<Detalle> listaDetalles = new List<Detalle>();

        [HttpGet]
        public ActionResult RegistrarVenta()
        {



            venta.Detalles = listaDetalles;
  
            listaDetalles.Add(new Detalle());
            return View(venta);

        }

        [HttpPost]
        public ActionResult HacerVenta(Venta venta, string agregarProducto, int idProducto, int idDetalle)
        {
            double total = 0;
            foreach (var detalle in venta.Detalles)
            {
                Usuario usuario = empresa.UsuarioEnUso;
                venta.Usuario = usuario;
                double subtotal = detalle.Cantidad * detalle.Precio;
                total += subtotal;
            }
            venta.Total = total;
            if (!string.IsNullOrEmpty(agregarProducto))
            {
   
                Producto producto = empresa.ObtenerProducto(idProducto);
                venta.Detalles[idDetalle].Producto = producto;

            }
            else
            {
                empresa.RegistrarVenta(venta);
            }

            // Resto de la lógica para registrar la venta

            return RedirectToAction("RegistrarVenta", venta);
        }






    }
}