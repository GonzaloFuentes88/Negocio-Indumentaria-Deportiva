using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitys.Entidades;
using DAL.Datos;

namespace BBL.Models
{
    public class NegocioCategoria
    {
        private CategoriaCon categoriaCon = CategoriaCon.GetCategoriaCon;
        public List<Categoria> ObtenerCategorias()
        {
            return categoriaCon.ObtenerCategorias();
        }
    }
}
