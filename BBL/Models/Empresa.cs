using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datos;
using System.Data;


namespace BBL.Models
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

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listUsuarios = new List<Usuario>();
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;

            DataTable dt = new DataTable();
            dt = usuarioCon.ObtenerUsuarios();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(dt.Rows[i]["Id_Usuario"]);
                usuario.Username = dt.Rows[i]["Username"].ToString();
                usuario.Password = dt.Rows[i]["Password"].ToString();
                usuario.Role = new Role(
                    Convert.ToInt32(dt.Rows[i]["Id_Rol"]),
                    dt.Rows[i]["NombreRol"].ToString()
                    );
                if(Convert.ToInt32(dt.Rows[i]["Estado"]) == 0)
                {
                    usuario.Estado = false;
                }
                else
                {
                    usuario.Estado = true;
                }

                listUsuarios.Add(usuario);
            }
            if(listUsuarios.Count > 0)
            {
                this.Usuarios = listUsuarios;
            }

            return listUsuarios;
        }

        public Usuario IniciarSesion(string user, string pass)
        {
            Usuario usuario = new Usuario();
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;

            DataTable dt = new DataTable();
            dt = usuarioCon.IniciarSesion(user,pass);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                usuario.IdUsuario = Convert.ToInt32(dt.Rows[i]["Id_Usuario"]);
                usuario.Username = dt.Rows[i]["Username"].ToString();
                usuario.Password = dt.Rows[i]["Password"].ToString();
                usuario.Role = new Role(
                    Convert.ToInt32(dt.Rows[i]["Id_Rol"]),
                    dt.Rows[i]["NombreRol"].ToString()
                    );
                if (Convert.ToInt32(dt.Rows[i]["Estado"]) == 0)
                {
                    usuario.Estado = false;
                }
                else
                {
                    usuario.Estado = true;
                }
            }

            return usuario;
        }



                
    }
}
