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
            Venta venta;

            if (Session["Venta"] == null)
            {
                venta = new Venta();
                venta.Detalles = new List<Detalle>();
                venta.Detalles.Add(new Detalle());

                Session["Venta"] = venta;
            }
            else
            {
                venta = (Venta)Session["Venta"];
            }

            return View(venta);
        }
        [HttpGet]
        public ActionResult CargarProducto(int Cantidad, int Precio, int idProducto)
        {
            Producto producto = empresa.ObtenerProducto(idProducto);

            Venta venta = (Venta)Session["Venta"];

            Detalle detalle = new Detalle();
            detalle.Cantidad = Cantidad;
            detalle.Precio = Precio;
            detalle.Producto = producto;
            venta.Detalles.Add(detalle);

            return RedirectToAction("RegistrarVenta");
        }
        [HttpPost]
        public ActionResult HacerVenta(Venta venta)
        {
            double total = 0;

            Venta ventaEnCurso = (Venta)Session["Venta"];

            foreach (var detalle in ventaEnCurso.Detalles)
            {
                Usuario usuario = empresa.UsuarioEnUso;
                ventaEnCurso.Usuario = usuario;
                double subtotal = detalle.Cantidad * detalle.Precio;
                total += subtotal;
            }

            ventaEnCurso.Total = total;
            empresa.RegistrarVenta(ventaEnCurso);

            Session.Remove("Venta"); 

            return RedirectToAction("RegistrarVenta");
        }





    }
}