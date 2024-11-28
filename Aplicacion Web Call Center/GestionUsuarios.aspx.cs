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

        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();

                nuevo.NombreUsuario = txtNombre.Text;
                nuevo.Correo = txtEmail.Text;
                nuevo.Rol = (Rol)Enum.Parse(typeof(Rol), ddlRolUsuario.SelectedItem.Text);
                nuevo.Contraseña = generarContraseñaAleatoria(8);

                negocio.insertarUsuarioConSp(nuevo);
                
                string cuerpo  = "<html><body><h1>Usuario dado de alta</h1><p>Su usuario " + txtNombre.Text + " ha sido dado de alta y su contraseña es: " + nuevo.Contraseña + "</p></body></html>";
                emailService.armarCorreo(txtEmail.Text, "Usuario dado de alta", cuerpo);
                emailService.enviarMail();

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