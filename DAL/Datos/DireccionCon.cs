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

        public Direccion RegistrarDireccion(Direccion direccion)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[3];
            int id = 0;

            parametros[0] = objConexion.crearParametro("@CP", direccion.CP);
            parametros[1] = objConexion.crearParametro("@Calle", direccion.Calle);
            parametros[2] = objConexion.crearParametro("@Numero", direccion.Numero);

            DataTable dt = objConexion.LeerPorStoreProcedure("sp_registrar_direccion", parametros);
            direccion.IDdireccion = Convert.ToInt32(dt.Rows[0]["ID"]);

            return direccion;
        }


    }
}
