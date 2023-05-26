using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBL.Models
{
    public class Role
    {
        private long _idRole;

        public long IdRole
        {
            get { return _idRole; }
            set { _idRole = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Role(long idRol, string nombre) 
        {
            this.IdRole = idRol;
            this.Nombre = nombre;
        }


    }
}