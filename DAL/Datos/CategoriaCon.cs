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
    public class CategoriaCon
    {
        private static CategoriaCon instance = null;
        public static CategoriaCon GetCategoriaCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new CategoriaCon();
                }
                return instance;
            }
        }
        private CategoriaCon() { }
        public List<Categoria> ObtenerCategorias()
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_categorias");
            List<Categoria> listCategoria = new List<Categoria>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Categoria categoria = new Categoria();
                categoria.idCategoria = Convert.ToInt32(dt.Rows[i]["Id_Categoria"]);
                categoria.Nombre = dt.Rows[i]["Nombre"].ToString();

                listCategoria.Add(categoria);
            }

            return listCategoria;

        }

    }
}
