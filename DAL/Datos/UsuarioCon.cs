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

        private UsuarioCon() { }
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

        public bool RegistrarUsuario(string username, string password,long idRole,long legajo)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[5];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Username", username);
            parametros[1] = objConexion.crearParametro("@Password", password);
            parametros[2] = objConexion.crearParametro("@Estado", 0);
            parametros[3] = objConexion.crearParametro("@Id_Rol", idRole);
            parametros[4] = objConexion.crearParametro("@Legajo",legajo);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_empleado",parametros);
            if(filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
        public DataTable BuscarUsuario(long idUsuario)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = objConexion.crearParametro("@Id_Usuario",idUsuario);
            DataTable dt = objConexion.LeerPorStoreProcedure("sp_buscar_usuario",parametros);

            return dt;
        }

        public bool EditarUsuario(long idUsuario, string username, string password)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[3];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id_Usuario", idUsuario);
            parametros[1] = objConexion.crearParametro("@Username", username);
            parametros[2] = objConexion.crearParametro("@Password", password);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_editar_usuario", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }


        public bool AltaUsuario(long idUsuario)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id_Usuario", idUsuario);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_alta_usuario", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
        public bool BajaUsuario(long idUsuario)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id_Usuario", idUsuario);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_baja_usuario", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
    }
}
