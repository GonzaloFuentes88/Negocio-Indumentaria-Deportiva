using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datos;
using Entitys.Entidades;

namespace BBL.Models
{
    public class NegocioRole
    {
        private RoleCon roleCon = RoleCon.GetUsuarioCon;
        public List<Role> ObtenerRoles()
        {
            return roleCon.ObtenerRoles();
        }
    }
}
