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
    public class RoleCon
    {
        private static RoleCon instance = null;
        public static RoleCon GetUsuarioCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new RoleCon();
                }
                return instance;
            }
        }
        private RoleCon() { }

        public List<Role> ObtenerRoles()
        {
            Conexion objConexion = Conexion.GetConexion;
            DataTable dt;
            List<Role> listRoles = new List<Role>();
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_roles");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Role role = new Role();
                role.IdRole = Convert.ToInt32(dt.Rows[i]["Id_Rol"]);
                role.Nombre = dt.Rows[i]["Tipo"].ToString();

                listRoles.Add(role);
            }

            return listRoles;
        }
    }
}
