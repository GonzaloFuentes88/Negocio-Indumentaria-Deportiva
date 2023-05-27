using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Datos
{
    public class UsuarioCon
    {
        private static UsuarioCon instance = null;
        public static UsuarioCon GetUsuarioCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new UsuarioCon();
                }
                return instance;
            }
        }

        public DataTable ObtenerUsuarios()
        {
            Conexion objConexion = Conexion.GetConexion;

            DataTable dt = objConexion.LeerPorStoreProcedure("sp_listar_usuarios");

            return dt;
        }

        public DataTable IniciarSesion(string user,string pass)
        {
            Conexion objConexion = Conexion.GetConexion;

            SqlParameter[] parametros = new SqlParameter[2];

            parametros[0] = objConexion.crearParametro("@Username", user);
            parametros[1] = objConexion.crearParametro("@Password", pass);

            DataTable dt = objConexion.LeerPorStoreProcedure("sp_login",parametros);

            return dt;
        }
    }
}
