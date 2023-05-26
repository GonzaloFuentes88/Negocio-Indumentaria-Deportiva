using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Models
{
    public class Proveedor
    {

        private long _idproveedor;
        public long idProveedor
        {
            get { return _idproveedor; }
            set { _idproveedor = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    

    

    public Proveedor(long idProveedor, string Nombre)
    {
        this.idProveedor = idProveedor;
        this.Nombre = Nombre;
    }

    }

}
