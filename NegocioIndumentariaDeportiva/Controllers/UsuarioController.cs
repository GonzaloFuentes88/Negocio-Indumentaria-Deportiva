using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBL.Models;

namespace NegocioIndumentariaDeportiva.Controllers
{
    public class UsuarioController : Controller
    {
        private Empresa empresa = Empresa.GetInstance;
        
        // GET: Usuario
        public ActionResult Listar()
        {
            var oList = empresa.ObtenerUsuarios();
            return View(oList);
        }

    }
}