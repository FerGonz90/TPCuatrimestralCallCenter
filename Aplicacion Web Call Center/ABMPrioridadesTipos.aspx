<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ABMPrioridadesTipos.aspx.cs" Inherits="Aplicacion_Web_Call_Center.ABMPrioridadesTipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Contenido/estilos.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="abm-container">

        <div class="abm-column">
            <label for="ddlTipoIncidencia">Tipo de Incidencia</label>
            <asp:DropDownList ID="ddlTipoIncidencia" runat="server"></asp:DropDownList>
            <asp:Button ID="btnAgregarTipoIncidencia" CssClass="btn btn-primary" runat="server" Text="Agregar" />
            <asp:Button ID="btnBorrarTipoIncidencia" CssClass="btn btn-primary" runat="server" Text="Borrar" />
            <asp:Button ID="btnModificarTipoIncidencia" CssClass="btn btn-primary" runat="server" Text="Modificar" />
        </div>

        <div class="abm-column">
            <label for="ddlPrioridad">Prioridad</label>
            <asp:DropDownList ID="ddlPrioridad" runat="server"></asp:DropDownList>
            <asp:Button ID="btnAgregarPrioridad" CssClass="btn btn-primary" runat="server" Text="Agregar" />
            <asp:Button ID="btnBorrarPrioridad" CssClass="btn btn-primary" runat="server" Text="Borrar" />
            <asp:Button ID="btnModificarPrioridad" CssClass="btn btn-primary" runat="server" Text="Modificar" />
        </div>
    </div>

</asp:Content>
