using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Datos;
using Entitys.Entidades;
using System.Data;

namespace BBL.Models
{
    public class NegocioUsuario
    {

        private UsuarioCon usuarioCon = UsuarioCon.GetUsuarioCon;
        //OBTENER TODOS LOS USUARIOS
        public List<Usuario> ObtenerUsuarios()
        {
            return usuarioCon.ObtenerUsuarios();
        }

        //OBTENER UN USUARIO
        public Usuario ObtenerUsuario(long idUsuario)
        {
            return usuarioCon.BuscarUsuario(idUsuario);
        }
        //REGISTRAR UN USUARIO
        public bool RegistrarUsuario(Usuario usuario)
        {
            return usuarioCon.RegistrarUsuario(usuario);
        }
        //BAJA USUARIO
        public bool bajaUsuario(long idUsuario)
        {
            return usuarioCon.BajaUsuario(idUsuario);
        }
        //ALTA USUARIO
        public bool altaUsuario(long idUsuario)
        {
            return usuarioCon.AltaUsuario(idUsuario);
        }

        //EDITAR USUARIO
        public bool EditarUsuario(Usuario usuario)
        {
            return usuarioCon.EditarUsuario(usuario);
        }


        //INICIAR SESION
        public Usuario IniciarSesion(string user, string pass)
        {
            return usuarioCon.IniciarSesion(user,pass);
        }
    }
}
