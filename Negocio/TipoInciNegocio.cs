using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso_Datos;
using System.Xml.Linq;
using dominio;
using System.Diagnostics.Eventing.Reader;

namespace Negocio
{
    public class TipoInciNegocio
    {
        public List<TipoIncidencia> listar()
        {
            List<TipoIncidencia> lista = new List<TipoIncidencia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select TipoIncidenciaID, Descripcion from TiposIncidencia");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    TipoIncidencia tipo = new TipoIncidencia();
                    tipo.Id = (int)datos.Lector["TipoIncidenciaID"];
                    tipo.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(tipo);
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
