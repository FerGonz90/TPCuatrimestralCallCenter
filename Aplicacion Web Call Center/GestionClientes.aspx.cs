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
    public partial class GestionClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                if (id != 0)
                {
                    try
                    {
                        btnAltaCliente.Text = "Modificar";
                        ClienteNegocio negocio = new ClienteNegocio();
                        Cliente cliente = negocio.filtrarPorId(id);

                        if (cliente != null)
                        {
                            txtNombre.Text = cliente.Nombre;
                            txtEmail.Text = cliente.Correo;
                            txtTelefono.Text = cliente.Telefono;
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", ex);
                        //redirigir a pagina de error
                    }
                }
            }
        }

        protected void btnAltaCliente_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(Request.QueryString["id"], out id);
            try
            {
                Cliente nuevo = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Correo = txtEmail.Text;
                nuevo.Telefono = txtTelefono.Text;

                if (id != 0)
                {
                    nuevo.ClienteID = id;
                    negocio.modificarClienteConSp(nuevo);
                }
                else
                    negocio.insertarClienteConSp(nuevo);

                Response.Redirect("Home.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}