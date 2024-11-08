<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionIncidencias.aspx.cs" Inherits="Aplicacion_Web_Call_Center.GestionIncidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Gestión de Incidencias</h2>

    <asp:Label ID="lblCliente" Text="Seleccionar Cliente" runat="server" />
    <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-control">
         <%--Aquí se cargarían los clientes desde la base de datos--%> 
    </asp:DropDownList>

    <asp:Label ID="lblTipoIncidencia" Text="Tipo de Incidencia" runat="server" />
    <asp:DropDownList ID="ddlTipoIncidencia" runat="server" CssClass="form-control">
        <%--Aquí se cargarían los tipos de incidencia desde la base de datos--%>
    </asp:DropDownList>

    <asp:Label ID="lblPrioridad" Text="Prioridad" runat="server" />
    <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="form-control">
         <%--Aquí se cargarían las prioridades desde la base de datos--%>
    </asp:DropDownList>

    <asp:Label ID="lblDescripcion" Text="Descripción del Reclamo" runat="server" />
    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control margen-inf" TextMode="MultiLine" Rows="4" />

    <asp:Button ID="btnCrearIncidencia" Text="Crear Incidencia" runat="server" OnClick="btnCrearIncidencia_Click" CssClass="btn btn-success" />

</asp:Content>
