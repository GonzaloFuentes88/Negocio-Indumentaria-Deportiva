using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Datos
{
    public class TalleCon
    {
        private static TalleCon instance = null;
        public static TalleCon GetTalleCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new TalleCon();
                }
                return instance;
            }
        }

        private TalleCon() { }

        public DataTable ObtenerTalles()
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_talles");

            return dt;
        }
    }
}
