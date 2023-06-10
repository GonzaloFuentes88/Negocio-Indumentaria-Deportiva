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
        public ActionResult CargarProducto(int idProducto, int Talle, int Cantidad, int Precio)
        {
            Producto producto = empresa.ObtenerProducto(idProducto);

            Venta venta = (Venta)Session["Venta"];

            Talle talle = new Talle();
            talle.idTalle = Talle;
            producto.Talle = talle;
            //hacer logica para que traiga el nombre del talle
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

        [HttpGet]
        public ActionResult RegistrarClienteGet(int DNI)
        {
            Cliente cliente = empresa.ObtenerClienteDNI(DNI); //arreglar, tira excepcion si no lo encuentra, deberia devolver null
            if (cliente != null)
            {
                return RedirectToAction("RegistrarVenta");
            }
            else
            {
                ModelState.AddModelError("", "Cliente no encontrado");
                return View();
            }
        }

        [HttpPost]
        public ActionResult RegistrarClientePost(Cliente cliente)
        {
 
            if(cliente != null)
            {
                empresa.RegistrarCliente(cliente);
                //SE CREA EL CLIENTE, REDIRIGILO A DONDE QUIERAS
                return RedirectToAction("Index");
            }
            return RedirectToAction("RegistrarCliente");
        }




    }
}