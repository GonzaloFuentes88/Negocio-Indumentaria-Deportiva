using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Datos
{
    public class DireccionCon
    {
        private static DireccionCon instance = null;
        public static DireccionCon GetDireccionCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new DireccionCon();
                }
                return instance;
            }
        }

        private DireccionCon() { }

        public int RegistrarDireccion(string cp,string calle,long numero)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[3];
            int id = 0;

            parametros[0] = objConexion.crearParametro("@CP", cp);
            parametros[1] = objConexion.crearParametro("@Calle", calle);
            parametros[2] = objConexion.crearParametro("@Numero", numero);

            DataTable dt = objConexion.LeerPorStoreProcedure("sp_registrar_direccion", parametros);
            id = Convert.ToInt32(dt.Rows[0]["ID"]);
            if (id > 0)
            {
                return id;
            }
            return 0;
        }


    }
}
