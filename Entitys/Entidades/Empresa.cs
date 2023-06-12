using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Entitys.Entidades
{
    public class Empresa
    {
        private static Empresa instance = null;

        private Empresa() { }

        public static Empresa GetInstance
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new Empresa();
                }
                return instance;
            }
        }

        private Usuario _usuarioEnUso;

        public Usuario UsuarioEnUso
        {
            get { return _usuarioEnUso; }
            set { _usuarioEnUso = value; }
        }
    }
}
