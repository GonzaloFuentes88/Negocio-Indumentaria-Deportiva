using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBL.Models;
using Entitys.Entidades;

namespace NegocioIndumentariaDeportiva.Controllers
{
    public class VendedorController : Controller
    {
        private Empresa empresa = Empresa.GetInstance;
        private NegocioVenta gestorVentas = new NegocioVenta();
        private NegocioTalle gestorTalles = new NegocioTalle();
        private NegocioProducto gestorProductos = new NegocioProducto();
        private NegocioCliente gestorCliente = new NegocioCliente();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult RegistrarVenta()
        {
            Venta venta;
            List<Talle> talles = new List<Talle>();
            talles = gestorTalles.ObtenerTalles();
            ViewBag.talles = talles;
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
        public ActionResult CargarProducto(int idProducto, int Cantidad, int Precio, int idTalle, string Talles)
        {
            Producto producto = gestorProductos.ObtenerProducto(idProducto);
            if (producto != null)
            {
                Venta venta = (Venta)Session["Venta"];
                Talle talle = new Talle();
                talle.idTalle = idTalle;
                talle.Talles = Talles;
                producto.Talle = talle;


                //hacer logica para que traiga el nombre del talle
                Detalle detalle = new Detalle();
                detalle.Cantidad = Cantidad;
                detalle.Precio = Precio;
                detalle.Producto = producto;
                venta.Detalles.Add(detalle);
                return RedirectToAction("RegistrarVenta");
            }
            else
            {
                ModelState.AddModelError("", "Producto no encontrado");
                return RedirectToAction("RegistrarVenta");
            }

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
            gestorVentas.RegistrarVenta(ventaEnCurso);

            Session.Remove("Venta"); 

            return RedirectToAction("RegistrarVenta");
        }

        [HttpGet]
        public ActionResult RegistrarClienteGet(int DNI)
        {
            Cliente cliente = gestorCliente.ObtenerClienteDNI(DNI); //arreglar, tira excepcion si no lo encuentra, deberia devolver null
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
                gestorCliente.RegistrarCliente(cliente);
                Venta venta = (Venta)Session["Venta"];
                venta.Cliente = cliente;
                //SE CREA EL CLIENTE, REDIRIGILO A DONDE QUIERAS
                return RedirectToAction("RegistrarVenta");
            }
            return RedirectToAction("RegistrarCliente");
        }




    }
}