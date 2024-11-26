using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Incidencia
    {
            public int Id { get; set; }
            public Cliente Cliente { get; set; }
            public TipoIncidencia Tipo { get; set; }
            public PrioridadIncidencia Prioridad { get; set; }
            public EstadoIncidencia Estado { get; set; }
            public string Problematica { get; set; }
            public Usuario UsuarioCreador { get; set; }
            public Usuario UsuarioAsignado { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaCierre { get; set; }
            public string ComentarioFinal { get; set; }
    }
}
