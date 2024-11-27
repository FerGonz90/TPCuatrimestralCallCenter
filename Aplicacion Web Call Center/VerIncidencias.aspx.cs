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
                cargarTiposIncidencia();
                cargarPrioridades();
                cargarEstados();

                ListItem seleccionarItem = new ListItem("Filtrar por", "");
                ddlTiposIncidencia.Items.Insert(0, seleccionarItem);
                ddlPrioridad.Items.Insert(0, seleccionarItem);
                ddlRol.Items.Insert(0, seleccionarItem);
                ddlEstado.Items.Insert(0, seleccionarItem);
            }
        }

        protected void cargarIncidencias()
        {
            IncidenciaNegocio negocio = new IncidenciaNegocio();
            Usuario usuario = (Usuario)Session["usuario"];

            if (Seguridad.Rol(usuario) == Rol.Telefonista)
            {
                Session.Add("listaIncidencias", negocio.listarInciConSP(usuario));
                dgvIncidencias.DataSource = Session["listaIncidencias"];

            }
            else
            {
                Session.Add("listaIncidencias", negocio.listarInciConSP());
                dgvIncidencias.DataSource = Session["listaIncidencias"];

            }

            dgvIncidencias.DataBind();
        }

        private void cargarTiposIncidencia()
        {
            TipoInciNegocio negocio = new TipoInciNegocio();
            List<TipoIncidencia> listaTipos = negocio.listar();

            ddlTiposIncidencia.DataSource = listaTipos;
            ddlTiposIncidencia.DataTextField = "Descripcion";
            ddlTiposIncidencia.DataValueField = "Id";
            ddlTiposIncidencia.DataBind();
        }

        private void cargarPrioridades()
        {
            PrioridadNegocio negocio = new PrioridadNegocio();
            List<PrioridadIncidencia> listaPrioridades = negocio.listar();

            ddlPrioridad.DataSource = listaPrioridades;
            ddlPrioridad.DataTextField = "Descripcion";
            ddlPrioridad.DataValueField = "Id";
            ddlPrioridad.DataBind();
        }

        private void cargarEstados()
        {
            EstadoNegocio negocio = new EstadoNegocio();
            List<EstadoIncidencia> listaEstados = negocio.listar();

            ddlEstado.DataSource = listaEstados;
            ddlEstado.DataTextField = "Descripcion";
            ddlEstado.DataValueField = "Id";
            ddlEstado.DataBind();
        }

        protected void dgvIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idIncidencia = dgvIncidencias.SelectedDataKey.Value.ToString();
            
            Response.Redirect("VerUsuarios.aspx?inciId=" + idIncidencia);
        }

        protected void dgvIncidencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvIncidencias.PageIndex = e.NewPageIndex;

            if (Session["listaInciFilt"] != null)
            {
                dgvIncidencias.DataSource = Session["listaInciFilt"];

                dgvIncidencias.DataBind();
            }
            else
                cargarIncidencias();


        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = cbxFiltroAvanzado.Checked;
            txtFiltroU.Text = "";
            tbxFiltro.Text = "";
            tbxFiltro.Enabled = !cbxFiltroAvanzado.Checked;
            txtFiltroU.Enabled = !cbxFiltroAvanzado.Checked;

            LimpiarFiltros();
        }

        protected void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> lista = new List<Incidencia>();
            if (Session["listaInciFilt"] != null)
                lista = (List<Incidencia>)Session["listaInciFilt"];
            else
                lista = (List<Incidencia>)Session["listaIncidencias"];

            List<Incidencia> listaFiltrada = lista.FindAll(x => x.Cliente.Nombre.ToUpper().Contains(tbxFiltro.Text.ToUpper()));
            dgvIncidencias.DataSource = listaFiltrada;
            Session["listaInciFilt"] = listaFiltrada;
            dgvIncidencias.DataBind();
        }

        protected void txtFiltroU_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> lista = new List<Incidencia>();
            if (Session["listaInciFilt"] != null)
                lista = (List<Incidencia>)Session["listaInciFilt"];
            else
                lista = (List<Incidencia>)Session["listaIncidencias"];

            List<Incidencia> listaFiltrada = lista.FindAll(x => x.UsuarioAsignado.NombreUsuario.ToUpper().Contains(txtFiltroU.Text.ToUpper()));
            dgvIncidencias.DataSource = listaFiltrada;
            Session["listaInciFilt"] = listaFiltrada;
            dgvIncidencias.DataBind();
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            Session["listaInciFilt"] = null;
            tbxFiltro.Text = "";
            txtFiltroU.Text = "";
            dgvIncidencias.DataSource = Session["listaIncidencias"];
            dgvIncidencias.DataBind();
        }

        protected void ddlTiposIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoInci = ddlTiposIncidencia.SelectedItem.Text;
            List<Incidencia> lista = new List<Incidencia>();

            lista = (List<Incidencia>)Session["listaIncidencias"];
            List<Incidencia> listaFiltrada = lista.FindAll(x => x.Tipo.Descripcion == tipoInci);
            dgvIncidencias.DataSource = listaFiltrada;
            Session["listaInciFilt"] = listaFiltrada;
            dgvIncidencias.DataBind();

            ocultarFiltros();
        }

        protected void ddlPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string prioridad = ddlPrioridad.SelectedItem.Text;
            List<Incidencia> lista = new List<Incidencia>();

            lista = (List<Incidencia>)Session["listaIncidencias"];
            List<Incidencia> listaFiltrada = lista.FindAll(x => x.Prioridad.Descripcion == prioridad);
            dgvIncidencias.DataSource = listaFiltrada;
            Session["listaInciFilt"] = listaFiltrada;
            dgvIncidencias.DataBind();

            ocultarFiltros();
        }

        private void ocultarFiltros()
        {
            cbxFiltroAvanzado.Checked = false;
            FiltroAvanzado = cbxFiltroAvanzado.Checked;
            tbxFiltro.Enabled = true;
            txtFiltroU.Enabled = true;
            ddlTiposIncidencia.SelectedIndex = 0;
            ddlPrioridad.SelectedIndex = 0;
            ddlRol.SelectedIndex = 0;
        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRol.SelectedIndex != 0)
            {
                string rol = ddlRol.SelectedItem.Text;

                Rol rolSeleccionado = (Rol)Enum.Parse(typeof(Rol), rol);

                List<Incidencia> lista = new List<Incidencia>();

                lista = (List<Incidencia>)Session["listaIncidencias"];
                List<Incidencia> listaFiltrada = lista.FindAll(x => x.UsuarioAsignado.Rol == rolSeleccionado);
                dgvIncidencias.DataSource = listaFiltrada;
                Session["listaInciFilt"] = listaFiltrada;
                dgvIncidencias.DataBind();

                ocultarFiltros();
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estado = ddlEstado.SelectedItem.Text;

            List<Incidencia> lista = new List<Incidencia>();

            lista = (List<Incidencia>)Session["listaIncidencias"];
            List<Incidencia> listaFiltrada = lista.FindAll(x => x.Estado.Descripcion == estado);
            dgvIncidencias.DataSource = listaFiltrada;
            Session["listaInciFilt"] = listaFiltrada;
            dgvIncidencias.DataBind();

            ocultarFiltros();
        }
    }
}