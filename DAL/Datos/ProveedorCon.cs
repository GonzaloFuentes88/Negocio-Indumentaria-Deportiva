using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entitys.Entidades;

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
        public Proveedor RegistrarProveedor(Proveedor proveedor)
        {
            Conexion objConexion = Conexion.GetConexion;
            DataTable dt = new DataTable();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = objConexion.crearParametro("@Nombre", proveedor.Nombre);
            parametros[1] = objConexion.crearParametro("@Numero", proveedor.Numero);

            dt = objConexion.LeerPorStoreProcedure("sp_registrar_proveedor", parametros);
            proveedor.idProveedor = Convert.ToInt32(dt.Rows[0]["ID"]);

            return proveedor;
        }

    }
}
