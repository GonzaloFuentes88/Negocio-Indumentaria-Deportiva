using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Models
{
      class Empleado : Persona
    {
        private long _legajo;

        public long Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

        public Empleado(long dni, string nombre, string apellido, long telefono, string email, Direccion direccion)
        {
            this.DNI = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Email = email;
            this.Direccion = direccion;
            
        }
    }
}
