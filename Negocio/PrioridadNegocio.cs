using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso_Datos;
using dominio;

namespace Negocio
{
    public class PrioridadNegocio
    {
        public List<PrioridadIncidencia> listar()
        {
            List<PrioridadIncidencia> lista = new List<PrioridadIncidencia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select PrioridadID, Descripcion from Prioridades");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    PrioridadIncidencia prioridad = new PrioridadIncidencia();
                    prioridad.Id = (int)datos.Lector["PrioridadID"];
                    prioridad.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(prioridad);
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
    }
}
