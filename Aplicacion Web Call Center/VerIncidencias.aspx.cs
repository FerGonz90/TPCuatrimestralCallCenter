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
    public partial class VerIncidencias : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = cbxFiltroAvanzado.Checked;
            if (!IsPostBack)
            {
                cargarIncidencias();
            }
        }

        protected void cargarIncidencias()
        {
            IncidenciaNegocio negocio = new IncidenciaNegocio();
            Usuario usuario = (Usuario)Session["usuario"];

            if(Seguridad.Rol(usuario) == Rol.Administrador)
                dgvIncidencias.DataSource = negocio.listarInciConSP();
            else
                dgvIncidencias.DataSource = negocio.listarInciConSP(usuario);

            
            dgvIncidencias.DataBind();
        }

        protected void dgvIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvIncidencias.SelectedDataKey.Value.ToString();
            Response.Redirect("VerUsuarios.aspx?id=" + id);
        }

        protected void dgvIncidencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvIncidencias.PageIndex = e.NewPageIndex;
            cargarIncidencias(); 
        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = cbxFiltroAvanzado.Checked;
        }

        protected void tbxFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}