﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Datos
{
    public class UsuarioCon
    {
        private static UsuarioCon instance = null;
        public static UsuarioCon GetUsuarioCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new UsuarioCon();
                }
                return instance;
            }
        }

        private UsuarioCon() { }
        public DataTable ObtenerUsuarios()
        {
            Conexion objConexion = Conexion.GetConexion;

            DataTable dt = objConexion.LeerPorStoreProcedure("sp_listar_usuarios");

            return dt;
        }

        public DataTable IniciarSesion(string user,string pass)
        {
            Conexion objConexion = Conexion.GetConexion;

            SqlParameter[] parametros = new SqlParameter[2];

            parametros[0] = objConexion.crearParametro("@Username", user);
            parametros[1] = objConexion.crearParametro("@Password", pass);

            DataTable dt = objConexion.LeerPorStoreProcedure("sp_login",parametros);

            return dt;
        }

        public bool RegistrarUsuario(string username, string password,long idRole,long legajo)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[4];
            int filasAfectadas = 0;

            parametros[1] = objConexion.crearParametro("@Username", username);
            parametros[2] = objConexion.crearParametro("@Password", password);
            parametros[2] = objConexion.crearParametro("@Estado", 0);
            parametros[3] = objConexion.crearParametro("@Id_Rol", idRole);
            parametros[4] = objConexion.crearParametro("@Legajo",legajo);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_empleado",parametros);
            if(filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
    }
}
