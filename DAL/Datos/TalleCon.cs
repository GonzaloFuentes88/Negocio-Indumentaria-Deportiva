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

        public List<Talle> ObtenerTalles()
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            List<Talle> listTalles = new List<Talle>();
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_talles");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Talle talle = new Talle();
                talle.idTalle = Convert.ToInt32(dt.Rows[i]["Id_Talle"]);
                talle.Talles = dt.Rows[i]["Talle"].ToString();

                listTalles.Add(talle);
            }

            return listTalles;
        }
        public bool RegistrarTalle(Talle talle)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = objConexion.crearParametro("@Talle",talle.Talles);
            int filasAfectadas = 0;

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_talle", parametro);

            if(filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
    }
}
