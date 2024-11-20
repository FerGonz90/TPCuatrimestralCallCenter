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
            string cod = Request.QueryString["cod"];

            if (!IsPostBack)
            {
                if (cod == "b")
                    ((CommandField)dgvClientes.Columns[5]).SelectText = "Seleccionar";

                ClienteNegocio negocio = new ClienteNegocio();
                dgvClientes.DataSource = negocio.listar();
                dgvClientes.DataBind();

            }
        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(dgvClientes.SelectedDataKey.Value);
            string cod = Request.QueryString["cod"];

            if (cod == "b")
                Response.Redirect("GestionIncidencias.aspx?id=" + idCliente);
            else
            Response.Redirect("GestionClientes.aspx?id=" + idCliente);
        }
    }
}