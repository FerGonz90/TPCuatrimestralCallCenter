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
                    aux.ClienteID = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Correo = (string)datos.Lector["Correo"];
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

        public Cliente filtrarPorId(int id)
        {
            Cliente clien = new Cliente();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select ClienteID, Nombre, Correo, Telefono From Clientes " +
                    "WHERE ClienteID = " + id;
                

                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    clien.ClienteID = (int)datos.Lector["ClienteID"];
                    clien.Nombre = (string)datos.Lector["Nombre"];
                    clien.Correo = (string)datos.Lector["Correo"];
                    clien.Telefono = (string)datos.Lector["Telefono"];
                }
                else
                {
                    return null;
                }
                
                return clien;
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
