using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Models
{
    public class Venta
    {
        private long _idventa;
        public long IdVenta
        {
            get { return _idventa; }
            set { _idventa = value; }
        }
 
        private Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }


        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private double _total;
        public double Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private List<Detalle> _detalles;

        public List<Detalle> Detalles
        {
            get { return _detalles; }
            set { _detalles = value; }
        }


        public Venta()
        {

        }



    }
}
