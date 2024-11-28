﻿using dominio;
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
            finally { datos.cerrarConexion(); }

        }

        public void modifIncidencia(int id, string proble, bool estado)
        {
            AccesoDatos datos = new AccesoDatos();
            int estadoInci;

            if(estado)
                estadoInci = 4;
            else
                estadoInci = 3;

            try
            {
                datos.setSP("storedModInci");
                datos.agregarParametro("@Id", id);
                datos.agregarParametro("@Problematica", proble);
                datos.agregarParametro("Estado", estadoInci);
                
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

        public void cerrarIncidencia(int id, string comen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setSP("storedCerrarInci");
                datos.agregarParametro("id", id);
                datos.agregarParametro("ComCierre", comen);
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

        public Incidencia listarInciPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Incidencia incidencia = new Incidencia();

            try
            {

                datos.setSP("storedListarInciPorId");
                datos.agregarParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    incidencia.Id = (int)datos.Lector["IncidenciaID"];
                    incidencia.Cliente = new Cliente();
                    incidencia.Cliente.Nombre = (string)datos.Lector["Nombre"];
                    incidencia.Tipo = new TipoIncidencia();
                    incidencia.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    incidencia.Prioridad = new PrioridadIncidencia();
                    incidencia.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    incidencia.Estado = new EstadoIncidencia();
                    incidencia.Estado.Descripcion = (string)datos.Lector["Estado"];
                    incidencia.Problematica = (string)datos.Lector["Problematica"];
                    incidencia.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    incidencia.UsuarioCreador = new Usuario();
                    incidencia.UsuarioAsignado = new Usuario();
                    incidencia.UsuarioCreador.NombreUsuario = (string)datos.Lector["Creador"];
                    incidencia.UsuarioAsignado.NombreUsuario = (string)datos.Lector["Asignado"];
                    //incidencia.ComentarioFinal = (string)datos.Lector["ComentarioCierre"];
                }



                return incidencia;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { datos.cerrarConexion(); }

        }

    }
}
