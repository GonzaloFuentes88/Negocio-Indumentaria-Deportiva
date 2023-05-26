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
        public long idVenta
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

       

        public Venta(long idVenta, Usuario usuario, Cliente cliente, DateTime fecha, double total)
        {
            this.IdVenta = idVenta;
            this.Usuario = usuario;
            this.Cliente = cliente;
            this.Fecha = fecha;
            this.Total = total;
        }

    }
}
