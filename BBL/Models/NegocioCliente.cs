using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitys.Entidades;
using DAL.Datos;

namespace BBL.Models
{
    public class NegocioCliente
    {
        private ClienteCon clienteCon = ClienteCon.GetClienteCon;
        public Cliente ObtenerClienteDNI(int dni)
        {
            try {
                Cliente cliente = clienteCon.ObtenerClienteDNI(dni);
                return cliente;
            }catch(Exception) {
                return null;
            }
        }

        public Cliente ObtenerCliente(long id)
        {
            return clienteCon.ObtenerCliente(id);
        }


        public bool RegistrarCliente(Cliente cliente)
        {
            return clienteCon.RegistrarCliente(cliente);
        }


    }
}
