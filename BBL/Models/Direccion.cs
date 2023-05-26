using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Models
{
    class Direccion
    {
        private long _idDireccion;

        public long IDdireccion
        {
            get { return _idDireccion; }
            set { _idDireccion = value; }
        }

        private string _cp;

        public string CP
        {
            get { return _cp; }
            set { _cp = value; }
        }

        private string _calle;

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        private long _numero;

        public long Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public Direccion(long idDir, string cp, string calle, long numero)
        {
            this.IDdireccion = idDir;
            this.CP = cp;
            this.Calle = calle;
            this.Numero = numero;
        }

    }
}
