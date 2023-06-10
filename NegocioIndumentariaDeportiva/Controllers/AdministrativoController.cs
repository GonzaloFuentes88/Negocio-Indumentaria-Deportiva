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


        [HttpGet]
        public ActionResult AgregarProducto()
        {
            List<Talle> talles = new List<Talle>();
            talles = empresa.ObtenerTalle();
            ViewBag.talles = talles;
            List<Categoria> categoria = new List<Categoria>();
            categoria = empresa.ObtenerCategoria();
            ViewBag.categoria = categoria;
            return View();
        }



        [HttpPost]
        public ActionResult DarAltaProducto(Producto producto)
        {
            
                if (producto.IdProducto == 0)
                {
                    bool registrado = empresa.RegistrarProducto(producto);
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
                    /*bool editado = empresa.EditarProducto(producto);*/
                    return RedirectToAction("Vertodos");
                }

            }
        }


    }
