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
    public partial class AdmIncidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtFechaCreacion.Enabled = false;
            txtEstado.Enabled = false;
            txtCliente.Enabled = false;
            txtUsuarioAsignado.Enabled = false;
            txtUsuarioCreador.Enabled = false;
            txtPrioridad.Enabled = false;
            txtTipo.Enabled = false;
            lblError.Visible = false;
            
            IncidenciaNegocio negocio = new IncidenciaNegocio();
            Incidencia incidencia = new Incidencia();
            int id;
            int.TryParse(Request.QueryString["inciId"], out id);

            if (!IsPostBack)
            {
                

                try
                {
                    if(id != 0)
                    {
                        incidencia = negocio.listarInciPorId(id);

                        Session.Add("incidencia", incidencia);

                        txtId.Text = incidencia.Id.ToString();
                        txtCliente.Text = incidencia.Cliente.Nombre;
                        txtTipo.Text = incidencia.Tipo.Descripcion;
                        txtPrioridad.Text = incidencia.Prioridad.Descripcion;
                        txtEstado.Text = incidencia.Estado.Descripcion;
                        txtFechaCreacion.Text = incidencia.FechaCreacion.ToString("dd/MM/yyyy");
                        txtUsuarioCreador.Text = incidencia.UsuarioCreador.NombreUsuario;
                        txtUsuarioAsignado.Text = incidencia.UsuarioAsignado.NombreUsuario;
                        txtProblematica.Text = incidencia.Problematica;
                    }
                    
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.Message);
                    Response.Redirect("Error.aspx");
                }
            }
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProblematica.Text) || string.IsNullOrWhiteSpace(txtProblematica.Text))
            {
                lblError.Visible = true;
                lblError.Text = "No puede dejar el campo de Problemática vacío";
            }
            else
            {
                if (!validarCambioProblem())
                {
                    lblError.Visible = true;
                    lblError.Text = "Debe agregar un comentario al campo de Problemática";
                }
                else
                {
                    lblError.Visible = false;
                    IncidenciaNegocio negocio = new IncidenciaNegocio();
                    int id = int.Parse(txtId.Text);
                    string proble = txtProblematica.Text;
                    negocio.modifIncidencia(id, proble, false);

                    Response.Redirect("VerIncidencias.aspx", false);
                }
            }



        }

        protected void btnResolver_Click(object sender, EventArgs e)
        {
            if(txtEstado.Text == "Abierto" || txtEstado.Text == "Asignado")
            {
                lblError.Visible = true;
                lblError.Text = "No puede dar por Resuelto una Incidencia en estado Abierto o Asignado";
            }
            else
            {
                if (string.IsNullOrEmpty(txtProblematica.Text) || string.IsNullOrWhiteSpace(txtProblematica.Text))
                {
                    lblError.Visible = true;
                    lblError.Text = "No puede dejar el campo de Problemática vacío";
                }
                else
                {
                    if (validarCambioProblem())
                    {
                        lblError.Visible = false;
                        IncidenciaNegocio negocio = new IncidenciaNegocio();
                        int id = int.Parse(txtId.Text);
                        string proble = txtProblematica.Text;
                        negocio.modifIncidencia(id, proble, true);

                        Response.Redirect("VerIncidencias.aspx", false);
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Debe agregar un comentario al campo de Problemática";
                    }
                }
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerIncidencias.aspx", false);
        }

        private bool validarCambioProblem()
        {
            Incidencia inciGuardada = (Incidencia)Session["incidencia"];
            
            if (txtProblematica.Text == inciGuardada.Problematica)
                return false;

            return true;
        }

        private bool validarCampoComFin()
        {
            if(!string.IsNullOrWhiteSpace(txtComentarioCierre.Text) || !string.IsNullOrEmpty(txtComentarioCierre.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Debe dejar un comentario para cerrar el incidente";
                return false;
            }
            return true;
        }
    }
}