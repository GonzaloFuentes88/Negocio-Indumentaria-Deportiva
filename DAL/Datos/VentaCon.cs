﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entitys.Entidades;

namespace DAL.Datos
{
    public class VentaCon
    {
        private static VentaCon instance = null;
        public static VentaCon GetVentaCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new VentaCon();
                }
                return instance;
            }
        }

        private VentaCon() { }


        public bool RegistrarVenta(Venta venta) 
        {
            Conexion objConexion = Conexion.GetConexion;

            SqlParameter[] parametros = new SqlParameter[4];
            int filasAfectadas = 0;

            parametros[0] = objConexion.crearParametro("@Id_Cliente", venta.Cliente.IdCliente);
            parametros[1] = objConexion.crearParametro("@Id_Usuario", venta.Usuario.IdUsuario);
            parametros[2] = objConexion.crearParametro("@Fecha", venta.Fecha);
            parametros[3] = objConexion.crearParametro("@Total", venta.Total);

            filasAfectadas = objConexion.EscribirPorStoreProcedure("sp_registrar_venta", parametros);
            if (filasAfectadas > 0)
            {
                return true;
            }
            return false;

        }

        public List<Venta> ObtenerVentas(DateTime fechaInicio, DateTime fechaFinal)
        {
            Conexion objConexion = Conexion.GetConexion;
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;
            ClienteCon clienteCon = ClienteCon.GetClienteCon;
            DetalleCon detalleCon = DetalleCon.GetDetalleCon;

            SqlParameter[] parametros = new SqlParameter[2];
            DataTable dt;

            parametros[0] = objConexion.crearParametro("@FechaInicio", fechaInicio);
            parametros[1] = objConexion.crearParametro("@FechaFin", fechaFinal);

            dt = objConexion.LeerPorStoreProcedure("sp_obtener_reporte",parametros);

            List<Venta> listVentas = new List<Venta>();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Venta venta = new Venta();

                venta.IdVenta = Convert.ToInt32(dt.Rows[i]["Id_Venta"]);
                venta.Total = Convert.ToInt32(dt.Rows[i]["Total"]);
                venta.Fecha = Convert.ToDateTime(dt.Rows[i]["Fecha"]);
                venta.Usuario = usuarioCon.BuscarUsuario(Convert.ToInt32(dt.Rows[i]["Id_Usuario"]));
                venta.Cliente = clienteCon.ObtenerCliente(Convert.ToInt32(dt.Rows[i]["Id_Cliente"]));
                venta.Detalles = detalleCon.ObtenerDetallesVenta(venta.IdVenta);

                listVentas.Add(venta);
            }

            return listVentas;
        }
        public List<Venta> ObtenerVentas()
        { 
            Conexion objConexion = Conexion.GetConexion;
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;
            ClienteCon clienteCon = ClienteCon.GetClienteCon;
            DetalleCon detalleCon = DetalleCon.GetDetalleCon;
            DataTable dt;

            dt = objConexion.LeerPorStoreProcedure("sp_obtener_ventas");


            List<Venta> listVentas = new List<Venta>();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Venta venta = new Venta();

                venta.IdVenta = Convert.ToInt32(dt.Rows[i]["Id_Venta"]);
                venta.Total = Convert.ToInt32(dt.Rows[i]["Total"]);
                venta.Fecha = Convert.ToDateTime(dt.Rows[i]["Fecha"]);
                venta.Usuario = usuarioCon.BuscarUsuario(Convert.ToInt32(dt.Rows[i]["Id_Usuario"]));
                venta.Cliente = clienteCon.ObtenerCliente(Convert.ToInt32(dt.Rows[i]["Id_Cliente"]));
                venta.Detalles = detalleCon.ObtenerDetallesVenta(venta.IdVenta);

                listVentas.Add(venta);
            }

            return listVentas;

        }

        


    }
}
