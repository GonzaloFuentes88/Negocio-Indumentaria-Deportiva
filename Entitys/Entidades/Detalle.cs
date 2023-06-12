using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Entidades
{
    public class Detalle
    {
        private long _iddetalle;
        public long IdDetalle
        {
            get { return _iddetalle; }
            set { _iddetalle = value; }
        }

        private Venta _venta;
        public Venta Venta
        {
            get { return _venta; }
            set { _venta = value; }
        }

        private Producto _producto;
        public Producto Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private double _precio;
        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public Detalle()
        {

        }


        public Detalle(long idDetalle, Venta venta, Producto producto, int cantidad, double precio)
        {
            this.IdDetalle = idDetalle;
            this.Venta = venta;
            this.Producto = producto;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

    }
}
