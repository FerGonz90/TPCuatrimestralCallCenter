using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion_Web_Call_Center
{
    public partial class VerUsuarios : System.Web.UI.Page
    {
        public bool FiltrarPorId {  get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltrarPorId = ckbFiltrarId.Checked;
            
            if (!IsPostBack)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Session.Add("listaUsuarios", negocio.listarUsuarioConSp());
                dgvListaUsuarios.DataSource = Session["listaUsuarios"];
                dgvListaUsuarios.DataBind();
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            List<Usuario> listaFiltrada = lista.FindAll(x => x.NombreUsuario.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvListaUsuarios.DataSource = listaFiltrada;
            dgvListaUsuarios.DataBind();
        }

        protected void ckbFiltrarId_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarPorId = ckbFiltrarId.Checked;
            txtFiltro.Text = "";
            txtFiltro.Enabled = !FiltrarPorId;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int id;
            if(int.TryParse(txtId.Text, out id) && id >= 1 && id <= 9999)
            {
                try
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = negocio.filtrarPorId(id);

                    if (usuario != null) 
                    {
                        List<Usuario> listaUnoSolo = new List<Usuario> { usuario};
                        dgvListaUsuarios.DataSource = listaUnoSolo;
                        dgvListaUsuarios.DataBind();
                        lblError.Visible = false;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "No se encontró un usuario con ese Id";
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
                lblError.Text = "Ingrese un valor entre 1 y 9999";
                lblError.Visible = true;
            }
        }

        protected void dgvListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IncidenciaNegocio negocio = new IncidenciaNegocio();
                int IdIncidencia = int.Parse(Request.QueryString["inciId"]);
                int IdUsuario =  int.Parse(dgvListaUsuarios.SelectedDataKey.Value.ToString());
                
                negocio.reasignarIncidencia(IdIncidencia, IdUsuario);
                Response.Redirect("Home.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvListaUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaUsuarios.PageIndex = e.NewPageIndex;
            UsuarioNegocio negocio = new UsuarioNegocio();

            dgvListaUsuarios.DataSource = negocio.listarUsuarioConSp();
            dgvListaUsuarios.DataBind();
        }
    }
}