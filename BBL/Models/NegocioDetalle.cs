using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datos;
using Entitys.Entidades;

namespace BBL.Models
{
    public class NegocioDetalle
    {
        private DetalleCon detalleCon = DetalleCon.GetDetalleCon;

        public List<Detalle> ObtenerDetalles(long id)
        {
            return detalleCon.ObtenerDetallesVenta(id);
        }

        public bool RegistrarDetalle(Detalle detalle)
        {
            return detalleCon.RegistrarDetalle(detalle);
        }
    }
}
