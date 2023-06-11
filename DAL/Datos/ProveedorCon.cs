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
        public static ProveedorCon GetProveedorCon
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
        public int RegistrarProveedor(string nombre, long numero)
        {
            Conexion objConexion = Conexion.GetConexion;
            DataTable dt = new DataTable();
            int id = 0;
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = objConexion.crearParametro("@Nombre", nombre);
            parametros[1] = objConexion.crearParametro("@Numero", numero);

            dt = objConexion.LeerPorStoreProcedure("sp_registrar_proveedor", parametros);
            id = Convert.ToInt32(dt.Rows[0]["ID"]);
            if (id > 0)
            {
                return id;
            }
            return 0;

        }

    }
}
