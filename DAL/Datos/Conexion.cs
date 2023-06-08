using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace DAL.Datos
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
            strCadenaDeConexion= @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TiendaDeportiva_tp;Data Source=localhost\SQLEXPRESS";
            //strCadenaDeConexion = @"Data Source=DESKTOP-LHGQJON;Initial Catalog=TiendaDeportiva_tp;Integrated Security=True;";
            //strCadenaDeConexion = @"Data Source=DESKTOP-LHGQJON;Initial Catalog=TiendaDeportiva_tp;Integrated Security=True;";
            strCadenaDeConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TiendaDeportiva_tp;Data Source=localhost\SQLEXPRESS";

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

        public DataTable LeerPorStoreProcedure(string pNombreStoreProcedure, SqlParameter[] pParametrosSql = null)
        {
            //Instancio un objeto del tipo DataTable
            var unaTabla = new DataTable();

            //Instancio un objeto del tipo SqlCommand
            var objComando = new SqlCommand();

            //Me conecto...
            this.Conectar();


            try
            {
                objComando.CommandText = pNombreStoreProcedure;
                objComando.CommandType = CommandType.StoredProcedure;
                objComando.Connection = this.objConexion;

                if (pParametrosSql != null)
                {
                    //Lleno los SqlParameters a la lista de parametros
                    objComando.Parameters.AddRange(pParametrosSql);
                }

                //Instancio un adaptador con el parametro SqlCommand
                var objAdaptador = new SqlDataAdapter(objComando);

                //Lleno la tabla, el objeto unaTabla con el adaptador
                objAdaptador.Fill(unaTabla);
            }
            catch (Exception)
            {
                //Como hay error... por el motivo que sea asigno el resultado a null
                unaTabla = null;

                throw;
            }
            finally
            {

                //Pase lo que pase me desconecto
                this.Desconectar();
            }

            return unaTabla;
        }

        public int EscribirPorStoreProcedure(string pTexto, SqlParameter[] pParametrosSql)
        {
            //Instanció una variable filasAfectadas que va a terminar devolviendo la cantidad de filas afectadas.
            int filasAfectadas = 0;

            //Instancio un objeto del tipo SqlCommand
            var objComando = new SqlCommand();

            //Me conecto...
            this.Conectar();

            try
            {
                objComando.CommandText = pTexto;
                objComando.CommandType = CommandType.StoredProcedure;
                objComando.Connection = this.objConexion;

                if (pParametrosSql.Length > 0)
                {
                    objComando.Parameters.AddRange(pParametrosSql);
                    //El método ExecuteNonQuery() me devuelve la cantidad de filas afectadas.
                    filasAfectadas = objComando.ExecuteNonQuery();
                }
                else
                {
                    //retorno -1 porque la lista de parametros Sql tiene 0 ítems...
                    filasAfectadas = -1;
                }



            }
            catch (Exception)
            {
                filasAfectadas = -1;
                throw;
            }
            finally
            {
                //Me desconecto
                this.Desconectar();
            }


            return filasAfectadas;
        }

        #region Parametros
        public SqlParameter crearParametro(string pNombre, string pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.String;

            return objParametro;
        }



        public SqlParameter crearParametro(string pNombre, double pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.Double;

            return objParametro;
        }


        public SqlParameter crearParametro(string pNombre, DateTime pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.DateTime;

            return objParametro;
        }


        public SqlParameter crearParametro(string pNombre, int pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.Int32;

            return objParametro;
        }


        public SqlParameter crearParametro(string pNombre, Boolean pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.Boolean;

            return objParametro;
        }
        #endregion


    }
}