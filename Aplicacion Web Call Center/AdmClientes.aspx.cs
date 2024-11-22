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
        public bool FiltrarPorId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltrarPorId = ckbFiltrarId.Checked;
            string cod = Request.QueryString["cod"];

            if (!IsPostBack)
            {
                if (cod == "b")
                    ((CommandField)dgvClientes.Columns[4]).SelectText = "Seleccionar";

                ClienteNegocio negocio = new ClienteNegocio();
                Session.Add("listaCliente", negocio.listar());
                dgvClientes.DataSource = Session["listaCliente"];
                dgvClientes.DataBind();

            }
        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCliente = (int)(dgvClientes.SelectedDataKey.Value);
            string cod = Request.QueryString["cod"];

            if (cod == "b")
                Response.Redirect("GestionIncidencias.aspx?id=" + idCliente);
            else
            Response.Redirect("GestionClientes.aspx?id=" + idCliente);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["listaCliente"];
            List<Cliente> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvClientes.DataSource = listaFiltrada;
            dgvClientes.DataBind();
        }

        protected void ckbFiltrarId_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarPorId = ckbFiltrarId.Checked;
            txtFiltro.Enabled = !FiltrarPorId;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtId.Text, out id) && id >= 1 && id <= 9999)
            {
                try
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente cliente = negocio.filtrarPorId(id);

                    if (cliente != null)
                    { 
                        List <Cliente> listaUnoSolo = new List<Cliente> { cliente};
                        dgvClientes.DataSource = listaUnoSolo;
                        dgvClientes.DataBind();
                        lblError.Visible = false;
                    }
                    else
                    {
                        lblError.Text = "No se encontró un cliente con ese ID.";
                        lblError.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.Message);
                    Response.Redirect("Error.aspx", false);
                }

            }
            else
            {
                lblError.Text = "Ingrese un valor entre 1 y 9999.";
                lblError.Visible = true;
            }
        }

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientes.PageIndex = e.NewPageIndex;
            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.listar();
            
            dgvClientes.DataBind();
        }
    }
}