using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace NegocioIndumentariaDeportiva.Datos
{
    /// <summary>
    /// Esta clase se utiliza para conectarse o desconectarse a la bd
    /// </summary>
    public class Conexion
    {
        //Instancia del objeto conexion
        private static Conexion instance = null;

        //Objeto que se conecta con la base de datos
        private SqlConnection objConexion;

        //String con la cadena de conexion (Se asigna al usar el metodo Conectar())
        private string strCadenaDeConexion = "";

        /// <summary>
        /// Constructor del objeto
        /// Es privado para que se instanci el obj mediante GetConexion
        /// </summary>
        private Conexion() { }


        /// <summary>
        /// GetConexion (Singleton)
        /// Basicamente existe una sola instancia de la conexion en todo el programa
        /// </summary>
        public static Conexion GetConexion
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if(instance == null)
                {
                    instance = new Conexion();
                }
                return instance;
            }
        }

        /// <summary>
        /// Sirve para conectarse a la base de datos
        /// </summary>
        /// <returns>Retorna un SqlConnection para realizar consultas en los distintos cruds</returns>
        public SqlConnection Conectar()
        {
            //Cambiar InitialCatalog y el Data Source por los propios
            strCadenaDeConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Sistema;Data Source=localhost\SQLEXPRESS";
            objConexion = new SqlConnection(strCadenaDeConexion);
            objConexion.Open();

            return objConexion;
        }


        /// <summary>
        /// Sirve para desconectarse de la base de datos
        /// </summary>
        public void Desconectar()
        {
            objConexion.Close();
            objConexion.Dispose();
        }
        

    }
}