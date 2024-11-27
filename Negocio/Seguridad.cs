using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web;
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
            if (!SesionActiva(user))
            {
                HttpContext.Current.Response.Redirect("Default.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                return default(Rol);
            }

            Usuario usuario = (Usuario)user;
            return usuario.Rol;
        }
    }
}
