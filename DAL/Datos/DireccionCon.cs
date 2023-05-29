using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        public bool RegistrarDireccion(string cp,string calle,long numero)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[3];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@CP", cp);
            parametros[1] = objConexion.crearParametro("@Calle", calle);
            parametros[2] = objConexion.crearParametro("@Numero", numero);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_direccion", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }


    }
}
