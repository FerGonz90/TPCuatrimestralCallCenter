using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; } // "Administrador", "Telefonista" o "Supervisor"
        public List<Incidencia> IncidenciasCreadas { get; set; }
        public List<Incidencia> IncidenciasAsignadas { get; set; }
    }
}
