using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Datos
{
    public class ClienteCon
    {
        private static ClienteCon instance = null;
        public static ClienteCon GetClienteCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new ClienteCon();
                }
                return instance;
            }
        }

        private ClienteCon() { }

        public DataTable ObtenerCliente(long id)
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = objConexion.crearParametro("@Id_Cliente", id);

            dt = objConexion.LeerPorStoreProcedure("sp_obtener_cliente", parametros);

            return dt;
        }

        public bool RegistrarCliente(long idDireccion, string nombre, string apellido, long dni, long telefono, string email)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[6];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id_Direccion", idDireccion);
            parametros[1] = objConexion.crearParametro("@Nombre", nombre);
            parametros[2] = objConexion.crearParametro("@Apellido", apellido);
            parametros[3] = objConexion.crearParametro("@DNI", dni);
            parametros[4] = objConexion.crearParametro("@Telefono", telefono);
            parametros[5] = objConexion.crearParametro("@Email", email);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_cliente", parametros);

            if(filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }

    }
}
