using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion_Web_Call_Center
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Default || Page is Error))
            {
                if (!Seguridad.SesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Default.aspx", false);
                    return;
                }
                    

                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario.Rol != Rol.Administrador)
                {
                    // Deshabilitar el enlace "ABM Tipo y Prioridad"
                    lnkABMTipoPrioridad.Attributes["class"] += " disabled";
                    lnkABMTipoPrioridad.Attributes["onclick"] = "return false;";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}