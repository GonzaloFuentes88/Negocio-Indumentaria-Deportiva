using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBL.Models;
using System.Data.SqlClient;
using System.Data;



namespace DAL.Datos.DaoImpl
{
    /// <summary>
    /// Clase para manipular los usuarios
    /// </summary>
    public class UsuarioDao : IGenericDao<UsuarioModel>
    {
        //Obtenemos la conexion
        private Conexion conexion = Conexion.GetConexion;

        public UsuarioDao() { }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioModel> FindAll()
        {
            List<UsuarioModel> usuarios = new List<UsuarioModel>();
            string query = "SELECT * FROM Usuarios"; 
            //string query = "sp_ListarUsuarios";
            using (SqlConnection connection = conexion.Conectar())
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    //sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = sqlCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            UsuarioModel usuario = new UsuarioModel();

                            usuario.Id = Convert.ToInt32(dr["ID_Usuario"]);
                            usuario.Nombre = dr["Nombre_Usuario"].ToString();
                            usuario.Email = dr["Email"].ToString();
                            usuario.Username = dr["Username"].ToString();
                            usuario.Password = dr["Password"].ToString();

                            usuarios.Add(usuario);

                        }

                    }
                }
            }
            conexion.Desconectar();

            return usuarios;
        }

        public UsuarioModel FindOne(int id)
        {
            UsuarioModel usuario = new UsuarioModel();
            string query = "SELECT * FROM Usuarios WHERE ID_Usuario = "+id;
            //string query = "sp_ObtenerUsuario";
            using (SqlConnection connection = conexion.Conectar())
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    //sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = sqlCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            usuario.Id = Convert.ToInt32(dr["ID_Usuario"]);
                            usuario.Nombre = dr["Nombre_Usuario"].ToString();
                            usuario.Email = dr["Email"].ToString();
                            usuario.Username = dr["Username"].ToString();
                            usuario.Password = dr["Password"].ToString();

                        }

                    }
                }
            }
            conexion.Desconectar();

            return usuario;

        }

        public bool Save(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }
    }
}