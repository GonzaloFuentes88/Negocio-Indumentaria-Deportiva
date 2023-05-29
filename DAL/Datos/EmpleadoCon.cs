﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        public bool RegistrarEmpleado(long idDireccion,string nombre,string apellido,long dni,long telefono,string email)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[6];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id_Direccion", idDireccion);
            parametros[1] = objConexion.crearParametro("@Nombre", nombre);
            parametros[2] = objConexion.crearParametro("@Apellido", apellido);
            parametros[3] = objConexion.crearParametro("@DNI", dni);
            parametros[4] = objConexion.crearParametro("@Telefono", telefono);
            parametros[5] = objConexion.crearParametro("@Email", email);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_empleado", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
    }
}