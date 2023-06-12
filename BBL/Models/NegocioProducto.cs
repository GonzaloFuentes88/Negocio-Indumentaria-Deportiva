using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitys.Entidades;
using DAL.Datos;

namespace BBL.Models
{
    public class NegocioProducto
    {
        private ProductoCon productoCon = ProductoCon.GetProductoCon;

        public List<Producto> ObtenerProductos()
        {
            return productoCon.ObtenerProductos();
        }
        public Producto ObtenerProducto(long idProducto)
        {
            return productoCon.ObtenerProducto(idProducto);
        }
        public bool RegistrarProducto(Producto producto)
        {
            return productoCon.RegistrarProducto(producto);
        }
        public bool EditarProducto(Producto producto)
        {
            return productoCon.EditarProducto(producto);
        }

    }
}
