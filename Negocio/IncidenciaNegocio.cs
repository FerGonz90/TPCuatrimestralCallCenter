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
        public List<Incidencia> listarInciConSP()
        {
            List<Incidencia> lista = new List<Incidencia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setSP("storedListarIncidencias");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
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
                    inci.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];

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
                datos.agregarParametro("@TipoID", nueva.Tipo.Id );
                datos.agregarParametro("@PrioridadID", nueva.Prioridad.Id);
                datos.agregarParametro("@Problematica", nueva.Problematica);
                datos.agregarParametro("@UsuarioCreadorID", nueva.UsuarioCreadorId);
                datos.agregarParametro("@UsuarioAsignadoID", nueva.UsuarioAsignadoId);
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
    }
}
