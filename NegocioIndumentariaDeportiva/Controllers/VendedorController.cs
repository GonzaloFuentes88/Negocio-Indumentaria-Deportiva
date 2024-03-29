﻿using System;
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

            if (Session["Venta"] == null)
            {
                venta = new Venta();
                venta.Detalles = new List<Detalle>();
                venta.Usuario = empresa.UsuarioEnUso;
                venta.Fecha = DateTime.Now;
                Session["Venta"] = venta;
            }
            else
            {
                venta = (Venta)Session["Venta"];

            }
            return View(venta);
        }
        [HttpPost]
        public ActionResult CargarProducto(Detalle detalle)
        {
            detalle.Producto = new Producto();
            detalle.Producto.IdProducto = detalle.IdDetalle;
            detalle.IdDetalle = 0;
            Producto producto = gestorProductos.ObtenerProducto(detalle.Producto.IdProducto);

            if (producto != null && detalle.Cantidad < producto.Cantidad)
            {

                Venta ventaEnCurso = (Venta)Session["Venta"];

                detalle.Producto.Precio = producto.Precio;
                detalle.Producto.Descripcion = producto.Descripcion;
                detalle.Producto.Categoria = producto.Categoria;
                detalle.Producto.Talle = producto.Talle;
                detalle.Precio = detalle.Producto.Precio * detalle.Cantidad;

                //ventaEnCurso.Detalles.Add(detalle);
                ventaEnCurso.Detalles.Add(detalle);
                return RedirectToAction("RegistrarVenta");
            }//agregar si existe el producto y el talle es igual aumentar cantidad 
            else
            {
                ModelState.AddModelError("", "El producto no se encuentra disponible.");
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
                double subtotal = detalle.Precio;
                total += subtotal;
            }

            //ventaEnCurso.Fecha = DateTime.Now;
            ventaEnCurso.Total = total;
            gestorVentas.RegistrarVenta(ventaEnCurso);

            Session.Remove("Venta");

            return RedirectToAction("RegistrarVenta");
        }


        [HttpGet]
        public ActionResult RegistrarClienteGet(int DNI)
        {
            Venta ventaEnCurso = (Venta)Session["Venta"];

            Cliente cliente = gestorCliente.ObtenerClienteDNI(DNI); //arreglar, tira excepcion si no lo encuentra, deberia devolver null
            if (cliente != null)
            {
                ventaEnCurso.Cliente = cliente;
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

            if (cliente != null)
            {
                gestorCliente.RegistrarCliente(cliente);
                Venta venta = (Venta)Session["Venta"];
                venta.Cliente = cliente;
                //SE CREA EL CLIENTE, REDIRIGILO A DONDE QUIERAS
                return RedirectToAction("RegistrarVenta");
            }
            return RedirectToAction("RegistrarCliente");
        }


        [HttpGet]
        public ActionResult Salir()
        {
            empresa.UsuarioEnUso = null;
            return RedirectToAction("Index", "Login");
        }




    }
}