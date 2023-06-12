using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entitys.Entidades;

namespace DAL.Datos
{
    public class DetalleCon
    {
        private static DetalleCon instance = null;
        public static DetalleCon GetDetalleCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new DetalleCon();
                }
                return instance;
            }
        }

        private DetalleCon() { }


        public bool RegistrarDetalle(Detalle detalle)
        {

            Conexion objConexion = Conexion.GetConexion;

            SqlParameter[] parametros = new SqlParameter[4];
            int filasAfectadas = 0;
            parametros[0] = objConexion.crearParametro("@Id_Venta", detalle.Venta.IdVenta);
            parametros[1] = objConexion.crearParametro("@Id_Producto", detalle.Producto.IdProducto);
            parametros[2] = objConexion.crearParametro("@Precio", detalle.Precio);
            parametros[3] = objConexion.crearParametro("@Cantidad", detalle.Cantidad);
            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_detalle", parametros);

            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;



        }
        public List<Detalle> ObtenerDetallesVenta(long idVenta)
        {
            Conexion objConexion = Conexion.GetConexion;
            ProductoCon productoCon = ProductoCon.GetProductoCon;
            SqlParameter[] parametros = new SqlParameter[1];
            DataTable dt;
            parametros[0] = objConexion.crearParametro("@Id_Venta", idVenta);
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_detalleV", parametros);
            List<Detalle> listDetalle = new List<Detalle>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Detalle detalle = new Detalle();

                detalle.IdDetalle = Convert.ToInt32(dt.Rows[i]["Id_Detalle"]);
                detalle.Precio = Convert.ToInt32(dt.Rows[i]["Precio"]);
                detalle.Producto = productoCon.ObtenerProducto(Convert.ToInt32(dt.Rows[i]["Id_Producto"]));
                detalle.Cantidad = Convert.ToInt32(dt.Rows[i]["Cantidad"]);

                listDetalle.Add(detalle);
            }

            return listDetalle;
        }
    }
}
