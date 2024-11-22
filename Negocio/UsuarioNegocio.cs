using Acceso_Datos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
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
