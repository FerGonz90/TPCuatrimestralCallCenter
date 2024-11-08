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
            public int ClienteId { get; set; }
            public TipoIncidencia Tipo { get; set; }
            public PrioridadIncidencia Prioridad { get; set; }
            public string Estado { get; set; }
            public string Problemática { get; set; }
            public int UsuarioCreadorId { get; set; }
            public int UsuarioAsignadoId { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaCierre { get; set; }
    }
}
