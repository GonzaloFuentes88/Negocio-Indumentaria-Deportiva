using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entitys.Entidades;
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


        public bool RegistrarProducto(Producto producto)
        {
            Conexion objConexion = Conexion.GetConexion;
            ProveedorCon proveedorCon = ProveedorCon.GetProveedorCon;
            SqlParameter[] parametros = new SqlParameter[6];
            int filasAfectadas = 0;

            producto.Proveedor = proveedorCon.RegistrarProveedor(producto.Proveedor);

            parametros[0] = objConexion.crearParametro("@Id_Categoria",producto.Categoria.idCategoria);
            parametros[1] = objConexion.crearParametro("@Id_Talle", producto.Talle.idTalle);
            parametros[2] = objConexion.crearParametro("@Id_Proveedor", producto.Proveedor.idProveedor);
            parametros[3] = objConexion.crearParametro("@Descripcion", producto.Descripcion);
            parametros[4] = objConexion.crearParametro("@Cantidad", producto.Cantidad);
            parametros[5] = objConexion.crearParametro("@Precio", producto.Precio);
            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_producto", parametros);

            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;
        }

        public List<Producto> ObtenerProductos()
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            List<Producto> listproductos = new List<Producto>();

            dt = objConexion.LeerPorStoreProcedure("sp_obtener_productos");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Producto producto = new Producto();
                producto.IdProducto = Convert.ToInt32(dt.Rows[i]["Id_Producto"]);
                producto.Descripcion = dt.Rows[i]["Descripcion"].ToString();
                producto.Precio = Convert.ToInt32(dt.Rows[i]["Precio"]);
                producto.Cantidad = Convert.ToInt32(dt.Rows[i]["Cantidad"]);
                producto.Categoria = new Categoria(
                Convert.ToInt32(dt.Rows[i]["Id_Categoria"]),
                   dt.Rows[i]["Nombre"].ToString()
           );
                producto.Talle = new Talle(
                    Convert.ToInt32(dt.Rows[i]["Id_Talle"]),
                        dt.Rows[i]["Talle"].ToString()
                );

                //listUsuarios.Add(usuario);
                listproductos.Add(producto);
            }

            return listproductos;

        }
        public Producto ObtenerProducto(long idProducto)
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = objConexion.crearParametro("@id",idProducto);
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_producto", parametros);

            if (dt == null || dt.Rows.Count == 0)
                return null;

            Producto producto = new Producto();

            producto.IdProducto = Convert.ToInt32(dt.Rows[0]["Id_Producto"]);
            producto.Descripcion = dt.Rows[0]["Descripcion"].ToString();
            producto.Precio = Convert.ToInt32(dt.Rows[0]["Precio"]);
            producto.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
            producto.Categoria = new Categoria(
                Convert.ToInt32(dt.Rows[0]["Id_Categoria"]),
                   dt.Rows[0]["Nombre"].ToString()
            );
            producto.Talle = new Talle(
                Convert.ToInt32(dt.Rows[0]["Id_Talle"]),
                dt.Rows[0]["Talle"].ToString()
            );

            return producto;

        }

        public bool EditarProducto(Producto producto)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[4];
            int filasAfectadas = 0;
            parametros[0] = objConexion.crearParametro("@id", producto.IdProducto);
            parametros[1] = objConexion.crearParametro("@Descripcion", producto.Descripcion);
            parametros[2] = objConexion.crearParametro("@Cantidad", producto.Cantidad);
            parametros[3] = objConexion.crearParametro("@Precio", producto.Precio);
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
