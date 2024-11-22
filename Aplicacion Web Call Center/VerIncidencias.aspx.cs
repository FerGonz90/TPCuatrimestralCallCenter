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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarIncidencias();
            }
        }

        protected void cargarIncidencias()
        {
            IncidenciaNegocio negocio = new IncidenciaNegocio();

            dgvIncidencias.DataSource = negocio.listarInciConSP();
            dgvIncidencias.DataBind();
        }

        protected void dgvIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvIncidencias.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionIncidencias.aspx?id=" + id);
        }

        protected void dgvIncidencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvIncidencias.PageIndex = e.NewPageIndex;
            cargarIncidencias(); 
        }
    }
}