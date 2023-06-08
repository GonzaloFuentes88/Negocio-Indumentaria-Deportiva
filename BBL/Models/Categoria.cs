using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Models
{
    public class Categoria
    {
        private long _idcategoria;
        public long idCategoria
        {
            get { return _idcategoria; }
            set { _idcategoria = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        public Categoria()
        {
        }
        public Categoria(int IdCategoria)
        {
                this.idCategoria = IdCategoria;

        }
    }
}
