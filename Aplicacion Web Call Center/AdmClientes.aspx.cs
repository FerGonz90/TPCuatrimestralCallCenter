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
    public partial class AdmClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
            }
        }

        private void cargarClientes()
        {
            
            /*var listaClientes = new List<Cliente>();

            listaClientes.Add(new Cliente { Id = 1, Nombre = "Juan Pérez", Email = "juan.perez@example.com", Telefono = "123456789", Direccion = "Calle Falsa 123" });
            listaClientes.Add(new Cliente { Id = 2, Nombre = "María Gómez", Email = "maria.gomez@example.com", Telefono = "987654321", Direccion = "Avenida Siempre Viva 456" });
            listaClientes.Add(new Cliente { Id = 3, Nombre = "Carlos Ruiz", Email = "carlos.ruiz@example.com", Telefono = "555555555", Direccion = "Boulevard de los Sueños Rotos 789" });
            */

            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.listar();
            dgvClientes.DataBind();
        }


        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvClientes.SelectedDataKey.Value.ToString();
            id = "2";
            Response.Redirect("GestionClientes.aspx?id=" + id);
        }
    }
}