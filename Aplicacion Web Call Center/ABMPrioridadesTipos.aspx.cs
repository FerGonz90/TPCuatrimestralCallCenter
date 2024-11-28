using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Aplicacion_Web_Call_Center
{
    public partial class ABMPrioridadesTipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.Rol(Session["usuario"]) != Rol.Administrador)
            {
                Session.Add("error", "Permisos insuficientes");
                Response.Redirect("Error.aspx", false);
                return;
            }
            else
            {
                if (!IsPostBack)
                {
                    try
                    {
                        lblABM.Visible = false;
                        txtABM.Visible = false;
                        btnConfAlta.Visible = false;
                        btnModificar.Visible = false;
                        btnBorrarPrioridad.Visible = false;
                        btnBorrarTipoIncidencia.Visible = false;

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

                    catch (Exception ex)
                    {
                        Session.Add("error", ex.Message);
                        Response.Redirect("Error.aspx");
                    }
                }
            }
        }

        protected void btnAgregarPrioridad_Click(object sender, EventArgs e)
        {
            try
            {
                txtABM.Visible = true;
                lblABM.Visible = true;
                btnConfAlta.Visible = true;
                btnModificar.Visible = false;
                lblABM.Text = "Ingrese la descripcion de la nueva Prioridad";

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnBorrarPrioridad_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarPrioridad_Click(object sender, EventArgs e)
        {
            try
            {
                txtABM.Visible = true;
                txtABM.Text = ddlPrioridad.SelectedItem.Text;
                lblABM.Visible = true;
                btnModificar.Visible = true;
                btnConfAlta .Visible = false;
                lblABM.Text = "Ingrese la descripcion de la Prioridad";

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }

        protected void btnConfAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtABM.Text) && !string.IsNullOrWhiteSpace(txtABM.Text))
                {
                    string descripcion = txtABM.Text;
                    if (lblABM.Text == "Ingrese la descripcion de la nueva Prioridad")
                    {
                        PrioridadNegocio negocio = new PrioridadNegocio();
                        
                        negocio.insertarPrioridad(descripcion);
                        Response.Redirect("ABMPrioridadesTipos.aspx", false);
                    }
                    else
                    {
                        TipoInciNegocio negocio = new TipoInciNegocio();

                        negocio.insertarTipoIncidencia(descripcion);
                        Response.Redirect("ABMPrioridadesTipos.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtABM.Text) && !string.IsNullOrWhiteSpace(txtABM.Text))
                {
                    string descripcion = txtABM.Text;
                    
                    if (lblABM.Text == "Ingrese la descripcion de la Prioridad")
                    {
                        int id = int.Parse(ddlPrioridad.SelectedValue);
                        PrioridadNegocio negocio = new PrioridadNegocio();

                        negocio.modificarPrioridad(descripcion, id);
                        Response.Redirect("ABMPrioridadesTipos.aspx", false);
                    }
                    else
                    {
                        int id = int.Parse(ddlTipoIncidencia.SelectedValue);
                        TipoInciNegocio negocio = new TipoInciNegocio();

                        negocio.modificarTipoIncidencia(descripcion, id);
                        Response.Redirect("ABMPrioridadesTipos.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregarTipoIncidencia_Click(object sender, EventArgs e)
        {
            try
            {
                txtABM.Visible = true;
                lblABM.Visible = true;
                btnConfAlta.Visible = true;
                btnModificar.Visible = false;
                lblABM.Text = "Ingrese la descripcion del nuevo Tipo de Incidencia";

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnModificarTipoIncidencia_Click(object sender, EventArgs e)
        {
            try
            {
                txtABM.Visible = true;
                txtABM.Text = ddlTipoIncidencia.SelectedItem.Text;
                lblABM.Visible = true;
                btnModificar.Visible = true;
                btnConfAlta.Visible = false;
                lblABM.Text = "Ingrese la descripcion del Tipo de Incidencia";

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }
    }
}