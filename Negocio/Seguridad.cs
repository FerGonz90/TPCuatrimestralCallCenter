using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool SesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;

            if (usuario != null && usuario.Id != 0)
                return true;
            else
            return false;
        }

        public static Rol Rol(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario.Rol;
        }
    }
}
