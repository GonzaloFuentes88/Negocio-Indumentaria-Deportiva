using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Entidades
{
    public class Cliente : Persona
    {
        private long _idCliente;

        public long IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public Cliente(long dni, string nombre, long telefono, string email, Direccion direccion)
        {
            this.DNI = dni;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
            this.Direccion = direccion;
        }

        public Cliente() { }

    }
}
