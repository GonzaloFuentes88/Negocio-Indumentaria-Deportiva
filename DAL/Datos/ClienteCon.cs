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

    }
}
