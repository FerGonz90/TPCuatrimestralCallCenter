using Acceso_Datos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<EstadoIncidencia> listar()
        {
            List<EstadoIncidencia> lista = new List<EstadoIncidencia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select EstadoID, Descripcion from Estados");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EstadoIncidencia estado = new EstadoIncidencia();
                    estado.Id = (int)datos.Lector["EstadoID"];
                    estado.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(estado);
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
