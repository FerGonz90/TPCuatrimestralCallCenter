using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso_Datos;

namespace Negocio
{
    public class IncidenciaNegocio
    {
        public List<Incidencia> listarInciConSP(Usuario usuario = null)
        {
            List<Incidencia> lista = new List<Incidencia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (usuario != null)
                {
                    datos.setSP("storedListarIncidenciaPropias");
                    datos.agregarParametro("UsuarioAsignadoID", usuario.Id);
                }
                else
                    datos.setSP("storedListarIncidencias");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidencia inci = new Incidencia();
                    inci.Id = (int)datos.Lector["IncidenciaId"];
                    inci.Cliente = new Cliente();
                    inci.Cliente.Nombre = (string)datos.Lector["Nombre"];
                    inci.Tipo = new TipoIncidencia();
                    inci.Tipo.Descripcion = (string)datos.Lector["Tipo Incidencia"];
                    inci.Prioridad = new PrioridadIncidencia();
                    inci.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    inci.Estado = new EstadoIncidencia();
                    inci.Estado.Descripcion = (string)datos.Lector["Estado"];
                    inci.UsuarioAsignado = new Usuario();
                    inci.UsuarioAsignado.NombreUsuario = (string)datos.Lector["Usuario Asignado"];
                    inci.UsuarioAsignado.Rol = (Rol)datos.Lector["RolID"];
                    inci.UsuarioAsignado.Id = (int)datos.Lector["UsuarioAsignadoID"];

                    lista.Add(inci);
                }

                return lista;
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


        public void insertarConSp(Incidencia nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setSP("storedInsertarIncidencia");
                datos.agregarParametro("@ClienteID", nueva.Cliente.ClienteID);
                datos.agregarParametro("@TipoID", nueva.Tipo.Id);
                datos.agregarParametro("@PrioridadID", nueva.Prioridad.Id);
                datos.agregarParametro("@Problematica", nueva.Problematica);
                datos.agregarParametro("@UsuarioCreadorID", nueva.UsuarioCreador.Id);
                datos.agregarParametro("@UsuarioAsignadoID", nueva.UsuarioAsignado.Id);
                datos.agregarParametro("@FechaCreacion", nueva.FechaCreacion);

                datos.ejecutarAccion();

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

        public void reasignarIncidencia(int idI, int idU) 
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setSP("storedReasignar");
                datos.agregarParametro("@IdUsuario", idU);
                datos.agregarParametro("@IdIncidencia", idI);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
   
        }
    }
}
