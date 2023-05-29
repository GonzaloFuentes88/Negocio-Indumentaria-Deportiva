using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Datos
{
    public class ProveedorCon
    {
        private static ProveedorCon instance = null;
        public static ProveedorCon GetUsuarioCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new ProveedorCon();
                }
                return instance;
            }
        }

        private ProveedorCon() { }



        public DataTable ObtenerProveedores()
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_proveedores");
            return dt;
        }

        public DataTable ObtenerProveedor(long idProducto)
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = objConexion.crearParametro("@Id_Producto", idProducto);
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_proveedor",parametros);
            return dt;
        }

        //sp_registrar_proveedor
        public bool RegistrarProveedor(string nombre, long numero)
        {
            Conexion objConexion = Conexion.GetConexion;
            int filasAfectadas = 0;
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = objConexion.crearParametro("@Nombre", nombre);
            parametros[1] = objConexion.crearParametro("@Numero", numero);
            filasAfectadas= objConexion.EscribirPorStoreProcedure("sp_registrar_proveedor", parametros);

            if(filasAfectadas > 0)
            {
                return true;
            }
            return false;
            
        }

    }
}
