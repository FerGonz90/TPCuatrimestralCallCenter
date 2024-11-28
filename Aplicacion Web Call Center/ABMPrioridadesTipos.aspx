<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ABMPrioridadesTipos.aspx.cs" Inherits="Aplicacion_Web_Call_Center.ABMPrioridadesTipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Contenido/estilos.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="abm-container">

        <div class="row">

            <div class="abm-column col-6 mb-3 mb-4">
                <label for="ddlTipoIncidencia">Tipo de Incidencia</label>
                <asp:DropDownList ID="ddlTipoIncidencia" runat="server"></asp:DropDownList>
                <asp:Button ID="btnAgregarTipoIncidencia" CssClass="btn btn-primary" OnClick="btnAgregarTipoIncidencia_Click" runat="server" Text="Agregar" />
                <asp:Button ID="btnBorrarTipoIncidencia" CssClass="btn btn-primary" runat="server" Text="Borrar" />
                <asp:Button ID="btnModificarTipoIncidencia" CssClass="btn btn-primary" OnClick="btnModificarTipoIncidencia_Click" runat="server" Text="Modificar" />
            </div>

            <div class="abm-column col-6 mb-3 mb-4">
                <label for="ddlPrioridad">Prioridad</label>
                <asp:DropDownList ID="ddlPrioridad" runat="server"></asp:DropDownList>
                <asp:Button ID="btnAgregarPrioridad" CssClass="btn btn-primary" OnClick="btnAgregarPrioridad_Click" runat="server" Text="Agregar" />
                <asp:Button ID="btnBorrarPrioridad" CssClass="btn btn-primary" OnClick="btnBorrarPrioridad_Click" runat="server" Text="Borrar" />
                <asp:Button ID="btnModificarPrioridad" CssClass="btn btn-primary" OnClick="btnModificarPrioridad_Click" runat="server" Text="Modificar" />
            </div>

        </div>

    </div>
    <div></div>
    <div></div>
    <div class="row">
        <div class="col-10 mb-3" >
            <asp:Label ID="lblABM" Text=" " runat="server" />
            <asp:TextBox ID="txtABM" CssClass="form-control mb-1" runat="server" />
            <asp:Button ID="btnConfAlta" OnClick="btnConfAlta_Click" CssClass="btn btn-success" Text="Confirmar" runat="server" />
            <asp:Button ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" Text="Modificar" runat="server" />
        </div>


    </div>
    <div>
        <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-primary" Text="Volver" runat="server" />
    </div>

</asp:Content>
