using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBL.Models
{
    public class Usuario
    {
        private int _idUsuario;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private Empleado _empleado;

        public Empleado Empleado
        {
            get { return _empleado; }
            set { _empleado = value; }
        } 

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool _estado;

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private Role _role;

        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }

       


    }
}