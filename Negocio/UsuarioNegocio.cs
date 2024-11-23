using Acceso_Datos;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                    aux.Rol = (string)datos.Lector["RolNombre"];

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
    }
}
