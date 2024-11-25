using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Aplicacion_Web_Call_Center
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var masterPage = this.Master;
            if (masterPage != null)
            {
                var navbar = masterPage.FindControl("navbar");
                if (navbar != null)
                {
                    navbar.Visible = false;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                if (negocio.Login(username, password, usuario))  
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Home.aspx", false);
                }
                else
                {
                    lblErrorMessage.Text = "Usuario o contraseña incorrectos.";
                    lblErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
            
        }
    }
}