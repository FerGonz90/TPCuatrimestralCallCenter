using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Aplicacion_Web_Call_Center
{
    public partial class GestionIncidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TipoInciNegocio negocio = new TipoInciNegocio();
                    List<TipoIncidencia> lista = negocio.listar();
                    PrioridadNegocio negocioPrioridades = new PrioridadNegocio();
                    List<PrioridadIncidencia> listaPrioridades = negocioPrioridades.listar();

                    ddlTipoIncidencia.DataSource = lista;
                    ddlTipoIncidencia.DataValueField = "Id";
                    ddlTipoIncidencia.DataTextField = "Descripcion";
                    ddlTipoIncidencia.DataBind();

                    ddlPrioridad.DataSource = listaPrioridades;
                    ddlPrioridad.DataValueField = "Id";
                    ddlPrioridad.DataTextField = "Descripcion";
                    ddlPrioridad.DataBind();

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);

                //redirecciono a pantalla de error
            }
        }

        protected void btnCrearIncidencia_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdmClientes.aspx?cod=b");
        }
    }
}