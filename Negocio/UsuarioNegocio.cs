using Acceso_Datos;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listarUsuarioConSp()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                datos.setSP("storedlistarUsuarioConSp");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["UsuarioID"];
                    aux.NombreUsuario = (string)datos.Lector["Nombre"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Rol = (Rol)datos.Lector["RolID"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void insertarUsuarioConSp(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setSP("storedInsertarUsuario");
                datos.agregarParametro("@Nombre", usuario.NombreUsuario);
                datos.agregarParametro("@Correo", usuario.Correo);
                datos.agregarParametro("@RolID", usuario.Rol);
                datos.agregarParametro("@Contraseña", usuario.Contraseña);

                datos.ejecutarAccion( );
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Login(string usuario, string contraseña, Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select UsuarioID, Nombre, Correo, RolID, Contraseña From Usuarios Where Nombre = @Nombre and Contraseña = @Contraseña");
                datos.agregarParametro("@Nombre", usuario);
                datos.agregarParametro("@Contraseña", contraseña);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["UsuarioID"];
                    user.NombreUsuario = (string)datos.Lector["Nombre"];
                    user.Correo = (string)datos.Lector["Correo"];
                    user.Rol = (Rol)datos.Lector["RolID"];
                    user.Contraseña = (string)datos.Lector["Contraseña"];

                    return true;
                }
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario filtrarPorId(int id)
        {
            Usuario usuario = new Usuario();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select UsuarioID, Nombre, Correo, RolID From Usuarios Where UsuarioID = " + id;

                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["UsuarioID"];
                    usuario.NombreUsuario = (string)datos.Lector["Nombre"];
                    usuario.Correo = (string)datos.Lector["Correo"];
                    usuario.Rol = (Rol)datos.Lector["RolID"];

                    return usuario;
                }
                else return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
