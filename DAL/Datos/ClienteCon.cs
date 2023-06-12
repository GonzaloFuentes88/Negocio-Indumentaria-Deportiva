using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitys.Entidades;

namespace DAL.Datos
{
    public class ClienteCon
    {
        private static ClienteCon instance = null;
        public static ClienteCon GetClienteCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new ClienteCon();
                }
                return instance;
            }
        }

        private ClienteCon() { }
        public Cliente ObtenerClienteDNI(int dni)
        {

            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            Cliente cliente = new Cliente();
            parametros[0] = objConexion.crearParametro("@DNI", dni);
            dt = objConexion.LeerPorStoreProcedure("sp_obtener_clienteDNI", parametros);
            
            if (dt == null || dt.Rows.Count == 0)
                return null;

            cliente.IdCliente = Convert.ToInt32(dt.Rows[0]["Id_Cliente"]);
            cliente.Nombre = dt.Rows[0]["Nombre"].ToString();
            cliente.Apellido = dt.Rows[0]["Apellido"].ToString();
            cliente.DNI = Convert.ToInt32(dt.Rows[0]["DNI"]);
            cliente.Email = dt.Rows[0]["Email"].ToString();
            cliente.Telefono = Convert.ToInt32(dt.Rows[0]["Telefono"]);
            cliente.Direccion = new Direccion(
                Convert.ToInt32(dt.Rows[0]["Id_Direccion"]),
                dt.Rows[0]["CP"].ToString(),
                dt.Rows[0]["Calle"].ToString(),
                Convert.ToInt32(dt.Rows[0]["Numero"])
                );

            return cliente;
        }
        public Cliente ObtenerCliente(long id)
        {
            DataTable dt;
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[1];
            Cliente cliente = new Cliente();
            parametros[0] = objConexion.crearParametro("@Id_Cliente", id);

            dt = objConexion.LeerPorStoreProcedure("sp_obtener_cliente", parametros);
            
            if (dt == null || dt.Rows.Count == 0)
                return null;


            cliente.IdCliente = Convert.ToInt32(dt.Rows[0]["Id_Cliente"]);
            cliente.Nombre = dt.Rows[0]["Nombre"].ToString();
            cliente.Apellido = dt.Rows[0]["Apellido"].ToString();
            cliente.DNI = Convert.ToInt32(dt.Rows[0]["DNI"]);
            cliente.Email = dt.Rows[0]["Email"].ToString();
            cliente.Telefono = Convert.ToInt32(dt.Rows[0]["Telefono"]);
            cliente.Direccion = new Direccion(
                Convert.ToInt32(dt.Rows[0]["Id_Direccion"]),
                dt.Rows[0]["CP"].ToString(),
                dt.Rows[0]["Calle"].ToString(),
                Convert.ToInt32(dt.Rows[0]["Numero"])
                );

            return cliente;

        }

        public bool RegistrarCliente(Cliente cliente)
        {
            Conexion objConexion = Conexion.GetConexion;
            SqlParameter[] parametros = new SqlParameter[6];
            int filasAfectadas = 0;

            DireccionCon direccionCon = DireccionCon.GetDireccionCon;

            if (cliente.Direccion != null)
            {
                Direccion dir = cliente.Direccion;
                cliente.Direccion = direccionCon.RegistrarDireccion(dir);
                if (dir.IDdireccion > 0)
                {
                    parametros[0] = objConexion.crearParametro("@Id_Direccion", cliente.Direccion.IDdireccion);
                    parametros[1] = objConexion.crearParametro("@Nombre", cliente.Nombre);
                    parametros[2] = objConexion.crearParametro("@Apellido", cliente.Apellido);
                    parametros[3] = objConexion.crearParametro("@DNI", cliente.DNI);
                    parametros[4] = objConexion.crearParametro("@Telefono", cliente.Telefono);
                    parametros[5] = objConexion.crearParametro("@Email", cliente.Email);

                    filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_cliente", parametros);

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;

            
        }
    }

}
