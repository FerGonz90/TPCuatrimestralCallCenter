using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Aplicacion_Web_Call_Center
{
    public partial class ABMPrioridadesTipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.Rol(Session["usuario"]) != Rol.Administrador)
            {
                Response.Redirect("Home.aspx", false); 
            }

        }
    }
}