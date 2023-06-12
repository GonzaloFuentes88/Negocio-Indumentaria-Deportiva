using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datos;
using Entitys.Entidades;

namespace BBL.Models
{
    public class NegocioTalle
    {
        private TalleCon talleCon = TalleCon.GetTalleCon;
        public List<Talle> ObtenerTalles()
        {
            return talleCon.ObtenerTalles();
        }

        public bool RegistrarTalle(Talle talle)
        {
            return talleCon.RegistrarTalle(talle);
        }
    }
}
