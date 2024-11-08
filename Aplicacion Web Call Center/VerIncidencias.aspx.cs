using dominio;
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
            var listaIncidencias = new List<Incidencia>();

            listaIncidencias.Add(new Incidencia { Id = 1, IdCliente = 1, IdTipoIncidencia = 1, IdPrioridad = 1, Estado = "Abierto" });
            listaIncidencias.Add(new Incidencia { Id = 2, IdCliente = 2, IdTipoIncidencia = 2, IdPrioridad = 2, Estado = "En Análisis" });
            listaIncidencias.Add(new Incidencia { Id = 3, IdCliente = 3, IdTipoIncidencia = 3, IdPrioridad = 2, Estado = "Resuelto" });

            dgvIncidencias.DataSource = listaIncidencias;
            dgvIncidencias.DataBind();
        }

        protected void dgvIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvIncidencias.SelectedDataKey.Value.ToString();
            id = "3";
            Response.Redirect("GestionIncidencias.aspx?id=" + id);
        }
    }
}