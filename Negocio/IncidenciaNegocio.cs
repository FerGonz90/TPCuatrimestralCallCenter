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
        public void insertar(Incidencia nueva)
        {
            AccesoDatos datos = new AccesoDatos();
                
            try
            {
                datos.setSP("storedInsertar");
                datos.agregarParametro("@Clien", nueva.Tipo.Id);
                datos.agregarParametro("@Tipo", nueva.Tipo.Id );
                datos.agregarParametro("@Priori", nueva.Tipo.Id);
                datos.agregarParametro("@Proble", nueva.Problematica);
                datos.agregarParametro("@Fecha", nueva.FechaCreacion);

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
