using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validación de usuario consultando base de datos.
            if (username == "ok" && password == "ok") // Ejemplo 
            {
                // Autenticación exitosa, redirigir a la página principal
                Response.Redirect("Home.aspx");
            }
            else
            {
                // Mostrar mensaje de error
                lblErrorMessage.Text = "Usuario o contraseña incorrectos.";
                lblErrorMessage.Visible = true;
            }
        }
    }
}