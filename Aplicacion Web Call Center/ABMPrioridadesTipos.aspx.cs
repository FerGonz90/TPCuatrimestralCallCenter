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
            try
            {
                if (Seguridad.Rol(Session["usuario"]) != Rol.Administrador)
                {
                    Session.Add("error", "Permisos insuficientes");
                    Response.Redirect("Error.aspx", false);
                    return;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }
    }
}