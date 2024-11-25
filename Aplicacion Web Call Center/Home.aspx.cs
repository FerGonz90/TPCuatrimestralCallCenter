using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion_Web_Call_Center
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAltaIncidencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionIncidencias.aspx");
        }

        protected void btnAltaClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionClientes.aspx");
        }

        protected void btnAltaUsuarios_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario.Rol == Rol.Administrador)
            {
                Response.Redirect("GestionUsuarios.aspx");
            }
            else
            {
                lblPermisos.Visible = true;
            }
        }
    }
}