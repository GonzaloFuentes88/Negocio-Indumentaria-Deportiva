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
    public class EmpleadoCon
    {
        private static EmpleadoCon instance = null;
        public static EmpleadoCon GetEmpleadoCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new EmpleadoCon();
                }
                return instance;
            }
        }

        private EmpleadoCon() { }

        public Empleado RegistrarEmpleado(Empleado empleado)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[6];

            parametros[0] = objConexion.crearParametro("@Id_Direccion", empleado.Direccion.IDdireccion);
            parametros[1] = objConexion.crearParametro("@Nombre", empleado.Nombre);
            parametros[2] = objConexion.crearParametro("@Apellido", empleado.Apellido);
            parametros[3] = objConexion.crearParametro("@DNI", empleado.DNI);
            parametros[4] = objConexion.crearParametro("@Telefono", empleado.Telefono);
            parametros[5] = objConexion.crearParametro("@Email", empleado.Email);

            DataTable dt = objConexion.LeerPorStoreProcedure("sp_registrar_empleado", parametros);
            empleado.Legajo = Convert.ToInt32(dt.Rows[0]["ID"]);


            return empleado;
        }
        
    }
}
