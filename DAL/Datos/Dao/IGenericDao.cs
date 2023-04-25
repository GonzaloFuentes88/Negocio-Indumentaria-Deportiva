using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBL.Models;

namespace DAL.Datos
{
    /// <summary>
    /// Interface generica para implementar Dao's sobre los distintos obj del proyecto
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericDao<T>
    {
        List<T> FindAll();
        T FindOne(int id);

        bool Save(UsuarioModel usuarioModel);

        bool Delete(int id);

    }
}
