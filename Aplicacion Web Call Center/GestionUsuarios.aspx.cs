using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion_Web_Call_Center
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                nuevo.NombreUsuario = txtNombre.Text;
                nuevo.Correo = txtEmail.Text;
                nuevo.Rol = ddlRolUsuario.Text;
                nuevo.Contraseña = generarContraseñaAleatoria(8);

                negocio.insertarUsuarioConSp(nuevo);

                Response.Redirect("Home.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        private string generarContraseñaAleatoria(int longitud)
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder contraseñaGenerada = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int indice = random.Next(caracteresPermitidos.Length);
                contraseñaGenerada.Append(caracteresPermitidos[indice]);
            }

            return contraseñaGenerada.ToString();
        }

    }
}