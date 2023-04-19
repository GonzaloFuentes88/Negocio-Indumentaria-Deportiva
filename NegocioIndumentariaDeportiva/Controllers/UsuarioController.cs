using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NegocioIndumentariaDeportiva.Datos;
using NegocioIndumentariaDeportiva.Datos.DaoImpl;

namespace NegocioIndumentariaDeportiva.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDao usuarioDao = new UsuarioDao();
        
        // GET: Usuario
        public ActionResult Listar()
        {

            var oList = usuarioDao.FindAll();
            return View(oList);
        }
    }
}