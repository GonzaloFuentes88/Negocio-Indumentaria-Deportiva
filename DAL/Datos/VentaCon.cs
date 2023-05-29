using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Datos
{
    public class VentaCon
    {
        private static VentaCon instance = null;
        public static VentaCon GetDireccionCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new VentaCon();
                }
                return instance;
            }
        }

        private VentaCon() { }

        public bool RegistrarVenta(long idCliente,long idUsuario,DateTime fecha,double total) 
        {
            Conexion objConexion = Conexion.GetConexion;

            SqlParameter[] parametros = new SqlParameter[4];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id_Cliente", idCliente);
            parametros[1] = objConexion.crearParametro("@Id_Usuario", idUsuario);
            parametros[2] = objConexion.crearParametro("@Fecha", fecha);
            parametros[3] = objConexion.crearParametro("@Total", total);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_venta", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;

        }

        public DataTable ObtenerVentas(DateTime fechaInicio, DateTime fechaFinal)
        {
            Conexion objConexion = Conexion.GetConexion;

            SqlParameter[] parametros = new SqlParameter[2];
            DataTable dt;

            parametros[0] = objConexion.crearParametro("@FechaInicio", fechaInicio);
            parametros[1] = objConexion.crearParametro("@FechaFin", fechaFinal);

            dt = objConexion.LeerPorStoreProcedure("sp_obtener_ventas",parametros);

            return dt;
        }


        public DataTable ObtenerDetallesVenta(long idVenta)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            DataTable dt;
            parametros[0] = objConexion.crearParametro("@Id_Venta", idVenta);
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_detalleV", parametros);

            return dt;
        }


    }
}
