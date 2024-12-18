﻿using dominio;
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
            Response.Redirect("GestionIncidencias.aspx", false);
        }

        protected void btnAltaClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionClientes.aspx", false);
        }

        protected void btnAltaUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario.Rol == Rol.Administrador)
                {
                    Response.Redirect("GestionUsuarios.aspx", false);
                }
                else
                {
                    lblPermisos.Visible = true;
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