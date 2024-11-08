using dominio;
using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setConsulta("Select c.ClienteID, c.Nombre, c.Correo, c.Telefono from Clientes c");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Email = (string)datos.Lector["Correo"];
                    aux.Telefono = (string)datos.Lector["Telefono"];

                    lista.Add(aux);

                }
               return lista;
            }
            catch(Exception ex)
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
