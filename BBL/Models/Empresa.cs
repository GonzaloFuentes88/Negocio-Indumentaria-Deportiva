using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Models
{
    class Empresa
    {
        private List<Usuario> _usuarios;

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }
        
                private Venta _ventas;

                public Venta Ventas
                {
                    get { return _ventas; }
                    set { _ventas = value; }
                }

                private Producto _productos;

                public Producto Productos
                {
                    get { return _productos; }
                    set { _productos = value; }
                }

             //   private ManipularDatos _datos;

            //    public ManipularDatos Datos
            //    {
            //        get { return _datos; }
             //       set { _datos = value; }
           //     }

                
    }
}
