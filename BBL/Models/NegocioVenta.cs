using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datos;
using Entitys.Entidades;

namespace BBL.Models
{
    public class NegocioVenta
    {
        private VentaCon ventaCon = VentaCon.GetVentaCon;
        private NegocioDetalle gestorDetalles = new NegocioDetalle();

        public bool RegistrarVenta(Venta venta)
        {
            List<Detalle> detalles = venta.Detalles;
            int idVenta = ventaCon.RegistrarVenta(venta);

            if (idVenta > 0) 
            {
                foreach (Detalle d in detalles)
                {
                    d.Venta = new Venta();
                    d.Venta.IdVenta = idVenta;
                    gestorDetalles.RegistrarDetalle(d);
                }
                return true;
            }

            return false;
        }

        public List<Venta> ObtenerVentas()
        {
            return ventaCon.ObtenerVentas();
        }
        public List<Venta> GenerarReporte(DateTime fecha1, DateTime fecha2)
        {
            return ventaCon.ObtenerVentas(fecha1,fecha2);
        }
        public double TotalReporte(List<Venta> ventas)
        {
            double total = 0;

            foreach (Venta v in ventas)
            {
                total += v.Total;
            }

            return total;
        }

    }
}