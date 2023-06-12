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
        public List<Usuario> ObtenerUsuarios()
        {
            Conexion objConexion = Conexion.GetConexion;
            DataTable dt = objConexion.LeerPorStoreProcedure("sp_listar_usuarios");

            List<Usuario> listUsuarios = new List<Usuario>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Usuario usuario = new Usuario();
                Direccion direccion = new Direccion();
                usuario.IdUsuario = Convert.ToInt32(dt.Rows[i]["Id_Usuario"]);
                usuario.Username = dt.Rows[i]["Username"].ToString();
                usuario.Password = dt.Rows[i]["Password"].ToString();
                usuario.Role = new Role(
                    Convert.ToInt32(dt.Rows[i]["Id_Rol"]),
                    dt.Rows[i]["Tipo"].ToString()
                    );
                direccion.IDdireccion = Convert.ToInt32(dt.Rows[i]["Id_Direccion"]);
                direccion.Calle = dt.Rows[i]["Calle"].ToString();
                direccion.CP = dt.Rows[i]["CP"].ToString();
                direccion.Numero = Convert.ToInt32(dt.Rows[i]["Numero"]);
                usuario.Empleado = new Empleado(
                    Convert.ToInt32(dt.Rows[i]["Legajo"]),
                    Convert.ToInt32(dt.Rows[i]["DNI"]),
                    dt.Rows[i]["Nombre"].ToString(),
                    dt.Rows[i]["Apellido"].ToString(),
                    Convert.ToInt32(dt.Rows[i]["Telefono"]),
                    dt.Rows[i]["Email"].ToString(),
                    direccion
                    );

                if (Convert.ToInt32(dt.Rows[i]["Estado"]) == 0)
                {
                    usuario.Estado = false;
                }
                else
                {
                    usuario.Estado = true;
                }

                listUsuarios.Add(usuario);
            }

            return listUsuarios;

        }

        public Usuario IniciarSesion(string user,string pass)
        {
            Conexion objConexion = Conexion.GetConexion;

            SqlParameter[] parametros = new SqlParameter[2];

            parametros[0] = objConexion.crearParametro("@Username", user);
            parametros[1] = objConexion.crearParametro("@Password", pass);

            DataTable dt = objConexion.LeerPorStoreProcedure("sp_login",parametros);

            Usuario usuario = new Usuario();

            if (dt == null || dt.Rows.Count == 0)
                return null;

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                usuario.IdUsuario = Convert.ToInt32(dt.Rows[i]["Id_Usuario"]);
                usuario.Username = dt.Rows[i]["Username"].ToString();
                usuario.Password = dt.Rows[i]["Password"].ToString();
                usuario.Role = new Role(
                    Convert.ToInt32(dt.Rows[i]["Id_Rol"]),
                    dt.Rows[i]["NombreRol"].ToString()
                    );
                if (Convert.ToInt32(dt.Rows[i]["Estado"]) == 0)
                {
                    usuario.Estado = false;
                }
                else
                {
                    usuario.Estado = true;
                }
            }


            return usuario;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[5];
            int filasAfectadas = 0;
            DireccionCon direccionCon = DireccionCon.GetDireccionCon;
            EmpleadoCon empleadoCon = EmpleadoCon.GetEmpleadoCon;

            if (usuario.Empleado.Direccion != null)
            {
                Direccion dir = usuario.Empleado.Direccion;
                usuario.Empleado.Direccion = direccionCon.RegistrarDireccion(dir);
                if (usuario.Empleado.Direccion.IDdireccion > 0)
                {
                    Empleado empl = usuario.Empleado;
                    usuario.Empleado = empleadoCon.RegistrarEmpleado(empl);
                    if (usuario.Empleado.Legajo > 0)
                    {
                        parametros[0] = objConexion.crearParametro("@Username", usuario.Username);
                        parametros[1] = objConexion.crearParametro("@Password", usuario.Password);
                        parametros[2] = objConexion.crearParametro("@Estado", usuario.Estado);
                        parametros[3] = objConexion.crearParametro("@Id_Rol", usuario.Role.IdRole);
                        parametros[4] = objConexion.crearParametro("@Legajo", usuario.Empleado.Legajo);

                        filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_usuario", parametros);

                        if(filasAfectadas > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public Usuario BuscarUsuario(long idUsuario)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = objConexion.crearParametro("@Id_Usuario",idUsuario);
            DataTable dt = objConexion.LeerPorStoreProcedure("sp_buscar_usuario",parametros);

            Usuario usuario = new Usuario();
            Direccion direccion = new Direccion();
            usuario.IdUsuario = Convert.ToInt32(dt.Rows[0]["Id_Usuario"]);
            usuario.Username = dt.Rows[0]["Username"].ToString();
            usuario.Password = dt.Rows[0]["Password"].ToString();
            usuario.Role = new Role(
                Convert.ToInt32(dt.Rows[0]["Id_Rol"]),
                dt.Rows[0]["Tipo"].ToString()
                );
            direccion.IDdireccion = Convert.ToInt32(dt.Rows[0]["Id_Direccion"]);
            direccion.Calle = dt.Rows[0]["Calle"].ToString();
            direccion.CP = dt.Rows[0]["CP"].ToString();
            direccion.Numero = Convert.ToInt32(dt.Rows[0]["Numero"]);
            usuario.Empleado = new Empleado(
                Convert.ToInt32(dt.Rows[0]["Legajo"]),
                Convert.ToInt32(dt.Rows[0]["DNI"]),
                dt.Rows[0]["Nombre"].ToString(),
                dt.Rows[0]["Apellido"].ToString(),
                Convert.ToInt32(dt.Rows[0]["Telefono"]),
                dt.Rows[0]["Email"].ToString(),
                direccion
                );

            if (Convert.ToInt32(dt.Rows[0]["Estado"]) == 0)
            {
                usuario.Estado = false;
            }
            else
            {
                usuario.Estado = true;
            }
            return usuario;
        }

        public bool EditarUsuario(Usuario usuario)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[4];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@id", usuario.IdUsuario);
            parametros[1] = objConexion.crearParametro("@Username", usuario.Username);
            parametros[2] = objConexion.crearParametro("@Password", usuario.Password);
            parametros[3] = objConexion.crearParametro("@Id_Rol", usuario.Role.IdRole);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_editar_usuario", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }


        public bool AltaUsuario(long idUsuario)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id", idUsuario);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_alta_usuario", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
        public bool BajaUsuario(long idUsuario)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id", idUsuario);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_baja_usuario", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
    }
}
