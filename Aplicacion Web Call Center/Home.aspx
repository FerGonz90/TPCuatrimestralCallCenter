<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplicacion_Web_Call_Center.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <h2>Bienvenido a la Aplicación de Call Center</h2>
    <p>Seleccione una opción para gestionar incidencias, clientes o usuarios.</p>
    
    <div class="menu">
        <asp:Button ID="btnAltaIncidencias" Text="Alta de Incidencias" runat="server" OnClick="btnAltaIncidencias_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnAltaClientes" Text="Alta de Clientes" runat="server" OnClick="btnAltaClientes_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnAltaUsuarios" Text="Alta de Usuarios" runat="server" OnClick="btnAltaUsuarios_Click" CssClass="btn btn-primary" />
    </div>

    <asp:Label ID="lblPermisos" Text="Permisos insuficientes" CssClass="text-danger" runat="server" Visible="false" />

</asp:Content>
