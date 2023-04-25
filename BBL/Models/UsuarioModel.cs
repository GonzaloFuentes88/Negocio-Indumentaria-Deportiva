using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBL.Models
{
    public class UsuarioModel
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string  Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
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

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private Role _role;

        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public UsuarioModel() { }


    }
}