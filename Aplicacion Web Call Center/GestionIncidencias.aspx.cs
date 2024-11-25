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

                    if (Request.QueryString["id"] != null)
                    {
                        string id = Request.QueryString["id"];
                        txtClientes.Text = id;
                    }

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
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCrearIncidencia_Click(object sender, EventArgs e)
        {
            try
            {
                int clienteId = int.Parse(txtClientes.Text);
                ClienteNegocio negocio2 = new ClienteNegocio();

                Cliente clienteExistente = negocio2.filtrarPorId(clienteId);
                
                if (clienteExistente == null)
                {
                    lblMensajeError.Text = "El Id de Cliente ingresado no existe.";
                    lblMensajeError.Visible = true;
                }
                else
                {
                    lblMensajeError.Visible = false;
                    Incidencia nueva = new Incidencia();
                    Usuario creador = new Usuario();
                    creador = (Usuario)Session["usuario"];
                    nueva.Cliente = new Cliente();
                    nueva.Tipo = new TipoIncidencia();
                    nueva.Prioridad = new PrioridadIncidencia();
                    IncidenciaNegocio negocio = new IncidenciaNegocio();

                    nueva.Cliente.ClienteID = int.Parse(txtClientes.Text);
                    nueva.Tipo.Id = int.Parse(ddlTipoIncidencia.SelectedValue);
                    nueva.Prioridad.Id = int.Parse(ddlPrioridad.SelectedValue);
                    nueva.Problematica = txtDescripcion.Text;
                    nueva.UsuarioCreadorId = creador.Id;
                    nueva.UsuarioAsignadoId = creador.Id;
                    nueva.FechaCreacion = DateTime.Now;

                    negocio.insertarConSp(nueva);

                    Response.Redirect("Home.aspx", false);
                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdmClientes.aspx?cod=b");
        }
    }
}