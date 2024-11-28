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
                try
                {
                    VisualizarPorRol();
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
                catch (Exception ex)
                {
                    Session.Add("error", ex.Message);
                    Response.Redirect("Error.apx");
                }
                
            }
        }

        protected void cargarIncidencias()
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }

        private void cargarTiposIncidencia()
        {
            try
            {
                TipoInciNegocio negocio = new TipoInciNegocio();
                List<TipoIncidencia> listaTipos = negocio.listar();

                ddlTiposIncidencia.DataSource = listaTipos;
                ddlTiposIncidencia.DataTextField = "Descripcion";
                ddlTiposIncidencia.DataValueField = "Id";
                ddlTiposIncidencia.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }

        private void cargarPrioridades()
        {
            try
            {
                PrioridadNegocio negocio = new PrioridadNegocio();
                List<PrioridadIncidencia> listaPrioridades = negocio.listar();

                ddlPrioridad.DataSource = listaPrioridades;
                ddlPrioridad.DataTextField = "Descripcion";
                ddlPrioridad.DataValueField = "Id";
                ddlPrioridad.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }

        private void cargarEstados()
        {
            try
            {
                EstadoNegocio negocio = new EstadoNegocio();
                List<EstadoIncidencia> listaEstados = negocio.listar();

                ddlEstado.DataSource = listaEstados;
                ddlEstado.DataTextField = "Descripcion";
                ddlEstado.DataValueField = "Id";
                ddlEstado.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void dgvIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string idIncidencia = dgvIncidencias.SelectedDataKey.Value.ToString();

                if (Seguridad.Rol(Session["usuario"]) == Rol.Telefonista)
                {
                    if (dgvIncidencias.SelectedRow.Cells[4].Text == "Resuelto" ||
                        dgvIncidencias.SelectedRow.Cells[4].Text == "Cerrado")
                    {
                        lblError.Visible = true;
                        lblError.Text = "No se puede trabajar con Incidencias Resueltas o Cerradas";
                    }
                    else
                    {
                        Response.Redirect("AdmIncidencias.aspx?inciId=" + idIncidencia, false);
                    }

                }
                else
                {
                    if (dgvIncidencias.SelectedRow.Cells[4].Text == "Resuelto" ||
                        dgvIncidencias.SelectedRow.Cells[4].Text == "Cerrado")
                    {
                        lblError.Visible = true;
                        btnSi.Visible = true;
                        btnNo.Visible = true;
                        lblError.Text = "No se puede reasignar Incidencias Resueltas o Cerradas. ¿Desea Reabrirla?";
                    }
                    else
                        Response.Redirect("VerUsuarios.aspx?inciId=" + idIncidencia, false);
                }
                    
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void dgvIncidencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblError.Visible = false;
            try
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
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }

        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
            FiltroAvanzado = cbxFiltroAvanzado.Checked;
            txtFiltroU.Text = "";
            tbxFiltro.Text = "";
            tbxFiltro.Enabled = !cbxFiltroAvanzado.Checked;
            txtFiltroU.Enabled = !cbxFiltroAvanzado.Checked;

            LimpiarFiltros();
        }

        protected void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
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
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void txtFiltroU_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
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
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            try
            {
                Session["listaInciFilt"] = null;
                tbxFiltro.Text = "";
                txtFiltroU.Text = "";
                dgvIncidencias.DataSource = Session["listaIncidencias"];
                dgvIncidencias.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void ddlTiposIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            
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
            try
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
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
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

        private void VisualizarPorRol()
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (Seguridad.Rol(usuario) == Rol.Telefonista)
            {
                lblFiltrarU.Visible = false;
                txtFiltroU.Visible = false;

                ((CommandField)dgvIncidencias.Columns[8]).SelectText = "Administrar";

                ddlRol.Enabled = false;
                //ddlTiposIncidencia.Enabled = false;
                //ddlPrioridad.Enabled = false;
                //ddlEstado.Enabled = false;
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            Usuario admin = (Usuario)Session["usuario"];
            int idAdmin = admin.Id;

            int idInci = (int)dgvIncidencias.SelectedDataKey.Value;
            IncidenciaNegocio negocio = new IncidenciaNegocio();

            negocio.reabrirIncidencia(idInci, idAdmin);

            Response.Redirect("VerIncidencias.aspx", false);

        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            btnNo.Visible = false;
            btnSi.Visible = false;
            lblError.Visible = false;
        }
    }
}