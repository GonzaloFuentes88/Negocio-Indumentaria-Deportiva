using BBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entitys.Entidades;

namespace NegocioIndumentariaDeportiva.Controllers
{
    public class GerenteController : Controller
    {
        // GET: Gerente
        private Empresa empresa = Empresa.GetInstance;
        private NegocioVenta gestorVentas = new NegocioVenta();
        private NegocioDetalle gestorDetalles = new NegocioDetalle();
        private NegocioUsuario gestorUsuarios = new NegocioUsuario();
        private NegocioCliente gestorCliente = new NegocioCliente();

        [HttpGet]
        public ActionResult Index()
        {
            var listVentas = gestorVentas.ObtenerVentas();
            return View(listVentas);
        }

        [HttpGet]
        public ActionResult VerDetalles(long id)
        {
            var listDetalles = gestorDetalles.ObtenerDetalles(id);
            if (listDetalles != null)
            {
                return View(listDetalles);
            }
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult VerCliente(long id)
        {
            Cliente cliente = gestorCliente.ObtenerCliente(id);
            if (cliente != null)
            {
                return View(cliente);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult VerVendedor(long id)
        {
            Usuario usuario = gestorUsuarios.ObtenerUsuario(id);
            if (usuario != null)
            {
                return View(usuario);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Reporte()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerarReporte(DateTime fecha1, DateTime fecha2)
        {
            List<Venta> reporte = gestorVentas.GenerarReporte(fecha1, fecha2);
            double total = gestorVentas.TotalReporte(reporte);
            if(reporte.Count > 0)
            {
                string fecha = fecha1.ToString("d") + " - " + fecha2.ToString("d");
                ViewBag.fecha1 = fecha1.ToString("d");
                ViewBag.fecha2 = fecha2.ToString("d");
                ViewBag.total = total;
                return new Rotativa.ViewAsPdf("GenerarReporte", reporte) {
                    PageSize = Rotativa.Options.Size.A4,
                    FileName = "Reporte: " + fecha + ".pdf",
                };
            }
            return RedirectToAction("Reporte");
            
        }

        [HttpGet]
        public ActionResult Salir()
        {
            empresa.UsuarioEnUso = null;
            return RedirectToAction("Index", "Login");
        }
    }
}