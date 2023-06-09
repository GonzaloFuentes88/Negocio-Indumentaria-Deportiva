using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datos;
using System.Data;


namespace BBL.Models
{
    public class Empresa
    {
        private static Empresa instance = null;

        private Empresa() { }

        public static Empresa GetInstance
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new Empresa();
                }
                return instance;
            }
        }

        private Usuario _usuarioEnUso;

        public Usuario UsuarioEnUso
        {
            get { return _usuarioEnUso; }
            set { _usuarioEnUso = value; }
        }

        public List<Role> ObtenerRoles()
        {
            List<Role> listRoles = new List<Role>();
            RoleCon RoleCon = RoleCon.GetUsuarioCon;
            DataTable dt = new DataTable();
            dt = RoleCon.ObtenerRoles();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Role role = new Role();
                role.IdRole = Convert.ToInt32(dt.Rows[i]["Id_Rol"]);
                role.Nombre = dt.Rows[i]["Tipo"].ToString();

                listRoles.Add(role);
            }

            return listRoles;
        }
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listUsuarios = new List<Usuario>();
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;

            DataTable dt = new DataTable();
            dt = usuarioCon.ObtenerUsuarios();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Usuario usuario = new Usuario();
                Direccion direccion = new Direccion();
                usuario.IdUsuario = Convert.ToInt32(dt.Rows[i]["Id_Usuario"]);
                usuario.Username = dt.Rows[i]["Username"].ToString();
                usuario.Password = dt.Rows[i]["Password"].ToString();
                usuario.Role = new Role(
                    Convert.ToInt32(dt.Rows[i]["Id_Rol"]),
                    dt.Rows[i]["Tipo"].ToString()
                    );
                direccion.IDdireccion = Convert.ToInt32(dt.Rows[i]["Id_Direccion"]);
                direccion.Calle = dt.Rows[i]["Calle"].ToString();
                direccion.CP = dt.Rows[i]["CP"].ToString();
                direccion.Numero = Convert.ToInt32(dt.Rows[i]["Numero"]);
                usuario.Empleado = new Empleado(
                    Convert.ToInt32(dt.Rows[i]["Legajo"]),
                    Convert.ToInt32(dt.Rows[i]["DNI"]),
                    dt.Rows[i]["Nombre"].ToString(),
                    dt.Rows[i]["Apellido"].ToString(),
                    Convert.ToInt32(dt.Rows[i]["Telefono"]),
                    dt.Rows[i]["Email"].ToString(),
                    direccion
                    );

                if(Convert.ToInt32(dt.Rows[i]["Estado"]) == 0)
                {
                    usuario.Estado = false;
                }
                else
                {
                    usuario.Estado = true;
                }

                listUsuarios.Add(usuario);
            }

            return listUsuarios;
        }

        public Usuario ObtenerUsuario(long idUsuario)
        {
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;
            DataTable dt = usuarioCon.BuscarUsuario(idUsuario);

            Usuario usuario = new Usuario();
            Direccion direccion = new Direccion();
            usuario.IdUsuario = Convert.ToInt32(dt.Rows[0]["Id_Usuario"]);
            usuario.Username = dt.Rows[0]["Username"].ToString();
            usuario.Password = dt.Rows[0]["Password"].ToString();
            usuario.Role = new Role(
                Convert.ToInt32(dt.Rows[0]["Id_Rol"]),
                dt.Rows[0]["Tipo"].ToString()
                );
            direccion.IDdireccion = Convert.ToInt32(dt.Rows[0]["Id_Direccion"]);
            direccion.Calle = dt.Rows[0]["Calle"].ToString();
            direccion.CP = dt.Rows[0]["CP"].ToString();
            direccion.Numero = Convert.ToInt32(dt.Rows[0]["Numero"]);
            usuario.Empleado = new Empleado(
                Convert.ToInt32(dt.Rows[0]["Legajo"]),
                Convert.ToInt32(dt.Rows[0]["DNI"]),
                dt.Rows[0]["Nombre"].ToString(),
                dt.Rows[0]["Apellido"].ToString(),
                Convert.ToInt32(dt.Rows[0]["Telefono"]),
                dt.Rows[0]["Email"].ToString(),
                direccion
                );

            if (Convert.ToInt32(dt.Rows[0]["Estado"]) == 0)
            {
                usuario.Estado = false;
            }
            else
            {
                usuario.Estado = true;
            }
            return usuario;

        }
      
        public Usuario IniciarSesion(string user, string pass)
        {

            Usuario usuario = new Usuario();
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;

            DataTable dt = new DataTable();
            dt = usuarioCon.IniciarSesion(user,pass);

            if (dt == null || dt.Rows.Count == 0)
                return null;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                usuario.IdUsuario = Convert.ToInt32(dt.Rows[i]["Id_Usuario"]);
                usuario.Username = dt.Rows[i]["Username"].ToString();
                usuario.Password = dt.Rows[i]["Password"].ToString();
                usuario.Role = new Role(
                    Convert.ToInt32(dt.Rows[i]["Id_Rol"]),
                    dt.Rows[i]["NombreRol"].ToString()
                    );
                if (Convert.ToInt32(dt.Rows[i]["Estado"]) == 0)
                {
                    usuario.Estado = false;
                }
                else
                {
                    usuario.Estado = true;
                }
            }


            return usuario;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            DireccionCon direccionCon = DireccionCon.GetDireccionCon;
            EmpleadoCon empleadoCon = EmpleadoCon.GetEmpleadoCon;
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;
            
            if(usuario.Empleado.Direccion != null)
            {
                Direccion dir = usuario.Empleado.Direccion;
                dir.IDdireccion = direccionCon.RegistrarDireccion(dir.CP, dir.Calle, dir.Numero);
                if (dir.IDdireccion > 0)
                {
                    Empleado empl = usuario.Empleado;
                    empl.Legajo = empleadoCon.RegistrarEmpleado(
                        dir.IDdireccion, empl.Nombre, empl.Apellido, empl.DNI, empl.Telefono, empl.Email);
                    if (empl.Legajo > 0)
                    {
                        if (usuarioCon.RegistrarUsuario(
                            usuario.Username,usuario.Password,usuario.Role.IdRole,empl.Legajo))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }

        public bool RegistrarVenta(Venta venta)
        {

            ProductoCon productoCon = ProductoCon.GetUsuarioCon;
            VentaCon ventaCon = VentaCon.GetVentaCon;

            ventaCon.RegistrarVenta(venta.Cliente.IdCliente, venta.Usuario.IdUsuario, venta.Fecha, venta.Total);

            return true;

        }
        /**public bool RegistrarDetalle(Detalle detalle, long idProd)
        {
            ProductoCon productoCon = ProductoCon.GetUsuarioCon;
            VentaCon ventaCon = VentaCon.GetVentaCon;

            detalle.Producto = ObtenerProducto(idProd);
            
            if (detalle.Producto != null)
            {

            }
            return false;

        }**/
        public Producto ObtenerProducto(long idProd)
        {
            ProductoCon productoCon = ProductoCon.GetUsuarioCon;
            DataTable dt = productoCon.ObtenerProducto(idProd);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            Producto producto = new Producto();

            producto.IdProducto = Convert.ToInt32(dt.Rows[0]["Id_Producto"]);
            producto.Descripcion = dt.Rows[0]["Descripcion"].ToString();
            producto.Precio = Convert.ToInt32(dt.Rows[0]["Precio"]);
            producto.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
            producto.Categoria = new Categoria(
                Convert.ToInt32(dt.Rows[0]["Id_Categoria"])
            );
            producto.Talle = new Talle(
                Convert.ToInt32(dt.Rows[0]["Id_Talle"]),
                dt.Rows[0]["Talle"].ToString()
            );

            return producto;

        }

        public bool bajaUsuario(long idUsuario)
        {
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;
            return usuarioCon.BajaUsuario(idUsuario);
        }

        public bool altaUsuario(long idUsuario)
        {
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;
            return usuarioCon.AltaUsuario(idUsuario);
        }

        public bool EditarUsuario(Usuario usuario)
        {
            UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;
            return usuarioCon.EditarUsuario(usuario.IdUsuario, usuario.Username, usuario.Password, usuario.Role.IdRole);
        }

        public Cliente ObtenerCliente(long id)
        {
            ClienteCon clienteCon = ClienteCon.GetClienteCon;
            DataTable dt = clienteCon.ObtenerCliente(id);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            Cliente cliente = new Cliente();

            cliente.IdCliente= Convert.ToInt32(dt.Rows[0]["Id_Cliente"]);
            cliente.Nombre= dt.Rows[0]["Nombre"].ToString();
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
        public List<Venta> ObtenerVentas()
        {
            List<Venta> listVentas = new List<Venta>();
            VentaCon ventaCon = VentaCon.GetVentaCon;

            DataTable dt = new DataTable();
            dt = ventaCon.ObtenerVentas();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Venta venta = new Venta();
                
                venta.IdVenta= Convert.ToInt32(dt.Rows[i]["Id_Venta"]);
                venta.Total = Convert.ToInt32(dt.Rows[i]["Total"]);
                venta.Fecha = Convert.ToDateTime(dt.Rows[i]["Fecha"]);
                venta.Usuario = this.ObtenerUsuario(Convert.ToInt32(dt.Rows[i]["Id_Usuario"]));
                venta.Cliente = this.ObtenerCliente(Convert.ToInt32(dt.Rows[i]["Id_Cliente"]));
                venta.Detalles = this.ObtenerDetalles(venta.IdVenta);

                listVentas.Add(venta);
            }

            return listVentas;
        }

        public List<Detalle> ObtenerDetalles(long id)
        {
            List<Detalle> listDetalle = new List<Detalle>();
            VentaCon ventaCon = VentaCon.GetVentaCon;

            DataTable dt = new DataTable();
            dt = ventaCon.ObtenerDetallesVenta(id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Detalle detalle = new Detalle();

                detalle.IdDetalle = Convert.ToInt32(dt.Rows[i]["Id_Detalle"]);
                detalle.Precio = Convert.ToInt32(dt.Rows[i]["Precio"]);
                detalle.Producto = this.ObtenerProducto(Convert.ToInt32(dt.Rows[i]["Id_Producto"]));
                detalle.Cantidad = Convert.ToInt32(dt.Rows[i]["Cantidad"]);

                listDetalle.Add(detalle);
            }

            return listDetalle;
        }

        public List<Venta> GenerarReporte(DateTime fecha1, DateTime fecha2)
        {
            List<Venta> listVentas = new List<Venta>();
            VentaCon ventaCon = VentaCon.GetVentaCon;

            DataTable dt = new DataTable();
            dt = ventaCon.ObtenerVentas(fecha1,fecha2);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Venta venta = new Venta();

                venta.IdVenta = Convert.ToInt32(dt.Rows[i]["Id_Venta"]);
                venta.Total = Convert.ToInt32(dt.Rows[i]["Total"]);
                venta.Fecha = Convert.ToDateTime(dt.Rows[i]["Fecha"]);
                venta.Usuario = this.ObtenerUsuario(Convert.ToInt32(dt.Rows[i]["Id_Usuario"]));
                venta.Cliente = this.ObtenerCliente(Convert.ToInt32(dt.Rows[i]["Id_Cliente"]));
                venta.Detalles = this.ObtenerDetalles(venta.IdVenta);

                listVentas.Add(venta);
            }

            return listVentas;
        }

        public double TotalReporte(List<Venta> ventas)
        {
            double total = 0;

            foreach(Venta v in ventas)
            {
                total += v.Total;
            }

            return total;


        }

    }
}
