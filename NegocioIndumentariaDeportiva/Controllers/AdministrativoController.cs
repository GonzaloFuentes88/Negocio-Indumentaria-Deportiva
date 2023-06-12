using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBL.Models;
using Entitys.Entidades;

namespace NegocioIndumentariaDeportiva.Controllers
{
    public class AdministrativoController : Controller
    {
        // GET: Administrativo
        private NegocioProducto gestorProductos = new NegocioProducto();
        private NegocioTalle gestorTalles = new NegocioTalle();
        private NegocioCategoria gestorCategorias = new NegocioCategoria();
        private Empresa empresa = Empresa.GetInstance;

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Vertodos");
        }

        [HttpGet]
        public ActionResult Vertodos()
        {
            List<Producto> productos = gestorProductos.ObtenerProductos();
            return View(productos);
        }



        [HttpPost]
        public ActionResult BuscarProducto(long idProd)
        {

            Producto producto = gestorProductos.ObtenerProducto(idProd);

            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Vertodos");

        }

        

        [HttpGet]
        public ActionResult EditarProducto(long id)
        {
            Producto producto = gestorProductos.ObtenerProducto(id);

            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Vertodos");

        }


        [HttpGet]
        public ActionResult AgregarProducto()
        {
            List<Talle> talles = gestorTalles.ObtenerTalles();
            ViewBag.talles = talles;
            List<Categoria> categoria = gestorCategorias.ObtenerCategorias();
            ViewBag.categoria = categoria;
            return View();
        }


        [HttpPost]
        public ActionResult DarAltaProducto(Producto producto)
        {
                if (producto.IdProducto == 0)
                {
                    bool registrado = gestorProductos.RegistrarProducto(producto);
                    if (registrado)
                    {
                        return RedirectToAction("AgregarProducto");
                    }
                    else
                    {
                        // El modelo no es válido, manejar los errores de validación
                        ModelState.AddModelError("", "No se pudo registrar el producto");
                        return RedirectToAction("AgregarProducto");
                    }
                }
                else
                {
                    bool editado = gestorProductos.EditarProducto(producto);
                    return RedirectToAction("Vertodos");
                }

            }
        public ActionResult Salir()
        {
            empresa.UsuarioEnUso = null;
            return RedirectToAction("Index", "Login");
        }


    }
    

    }
