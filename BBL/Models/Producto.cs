using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Models
{
    public class Producto
    {
        private long _idproducto;
        public long IdProducto
        {
            get { return _idproducto; }
            set { _idproducto = value; }
        }

        private Categoria _categoria;
        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private Talle _talle;
        public Talle Talle
        {
            get { return _talle; }
            set { _talle = value; }
        }

        private Proveedor _proveedor;
        public Proveedor Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private double _precio;
        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public Producto()
        {
        }

        public Producto CargarProducto(long idProducto, Categoria categoria, Talle talle, Proveedor proveedor, string descripcion, double precio, int cantidad)
        {
            Producto unProducto = new Producto();
            unProducto.IdProducto = idProducto;
            unProducto.Categoria = categoria;
            unProducto.Talle = talle;
            unProducto.Proveedor = proveedor;
            unProducto.Descripcion = descripcion;
            unProducto.Precio = precio;
            unProducto.Cantidad = cantidad;
            return unProducto;
        }


    }
}
