using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Datos
{
    public class CategoriaCon
    {
        private static CategoriaCon instance = null;
        public static CategoriaCon GetUsuarioCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new CategoriaCon();
                }
                return instance;
            }
        }
        private CategoriaCon() { }
        public DataTable ObtenerCategorias()
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_categorias");

            return dt;
        }

    }
}
