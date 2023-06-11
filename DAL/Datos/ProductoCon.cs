﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Datos
{
    public class ProductoCon
    {
        private static ProductoCon instance = null;
        public static ProductoCon GetProductoCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new ProductoCon();
                }
                return instance;
            }
        }

        private ProductoCon() { }


        public bool RegistrarProducto(long idCategoria,long idTalle,string descripcion,int cantidad,long idProveedor,double precio)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[5];
            int filasAfectadas = 0;


            parametros[0] = objConexion.crearParametro("@Id_Categoria",idCategoria);
            parametros[1] = objConexion.crearParametro("@Id_Talle", idTalle);
            parametros[2] = objConexion.crearParametro("@Id_Proveedor", idProveedor);
            parametros[3] = objConexion.crearParametro("@Descripcion", descripcion);
            parametros[4] = objConexion.crearParametro("@Cantidad", cantidad);
            parametros[5] = objConexion.crearParametro("@Precio", precio);
            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_producto", parametros);

            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }

        public DataTable ObtenerProductos()
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_productos");

            return dt;

        }
        public DataTable ObtenerProducto(long idProducto)
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = objConexion.crearParametro("@id",idProducto);

            dt = objConexion.LeerPorStoreProcedure("sp_obtener_producto",parametros);

            return dt;
        }

        public bool EditarProducto(long idProducto,string descripcion,long cantidad,double precio)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[4];
            int filasAfectadas = 0;
            parametros[0] = objConexion.crearParametro("@id", idProducto);
            parametros[1] = objConexion.crearParametro("@Descripcion", descripcion);
            parametros[2] = objConexion.crearParametro("@Cantidad", cantidad);
            parametros[3] = objConexion.crearParametro("@Precio", precio);
            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_editar_producto", parametros);

            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }
        public bool EliminarProducto(long idProducto)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            int filasAfectadas = 0;
            parametros[0] = objConexion.crearParametro("@id", idProducto);
            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_eliminar_producto", parametros);

            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;

        }
    }
}
