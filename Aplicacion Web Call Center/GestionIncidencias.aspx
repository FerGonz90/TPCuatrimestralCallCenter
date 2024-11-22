<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionIncidencias.aspx.cs" Inherits="Aplicacion_Web_Call_Center.GestionIncidencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Gestión de Incidencias</h2>

    <div class="row mb-3">

        <div class="col-4">
            <div class="form-group">
                <asp:Label ID="lblCliente" Text="Id del Cliente" runat="server" />
                <asp:TextBox ID = "txtClientes" runat = "server" CssClass = "form-control me-2" TextMode = "Number" Style = "width: 80px;" />
                <asp:Label ID="lblError" runat="server" CssClass="text-danger ms-2" Visible="false" />
                <div class="form-group">
                    <asp:Button ID="btnBuscarCliente" CssClass="btn btn-primary" OnClick="btnBuscarCliente_Click" Text="Buscar cliente" runat="server" />
                </div>

            </div>
        </div>

        <div class="col-4">
            <div class="form-group">
                <asp:Label ID="lblTipoIncidencia" Text="Tipo de Incidencia" runat="server" />
                <asp:DropDownList ID="ddlTipoIncidencia" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-4">
            <div class="form-group">
                <asp:Label ID="lblPrioridad" Text="Prioridad" runat="server" />
                <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="row mb-3">

        <div class="col-6">
            <div class="form-group">
                <asp:Label ID="lblDescripcion" Text="Descripción del Reclamo" runat="server" />
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Button ID="btnCrearIncidencia" Text="Crear Incidencia" runat="server" OnClick="btnCrearIncidencia_Click" CssClass="btn btn-success" />
                <a href="Home.aspx">Cancelar</a>
            </div>
            <div>
                <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
        </div>
    </div>


</asp:Content>
