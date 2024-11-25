using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Seguridad
{
    public static class Permisos
    { 
        public static bool EsAdministrador(Rol rol)
        {
            return rol == Rol.Administrador;
        }

        public static bool EsTelefonista(Rol rol)
        {
            return rol == Rol.Telefonista;
        }

    }
}
