<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="Aplicacion_Web_Call_Center.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Administración de Usuarios</h2>

    <asp:Label ID="lblNombreUsuario" Text="Nombre del Usuario" runat="server" />
    <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" />

    <asp:Label ID="lblEmailUsuario" Text="Email del Usuario" runat="server" />
    <asp:TextBox ID="txtEmailUsuario" runat="server" CssClass="form-control" />

    <asp:Label ID="lblRolUsuario" Text="Rol del Usuario" runat="server" />
    <asp:DropDownList ID="ddlRolUsuario" runat="server" CssClass="form-control margen-inf">
        <asp:ListItem Text="Administrador" Value="1" />
        <asp:ListItem Text="Telefonista" Value="2" />
        <asp:ListItem Text="Supervisor" Value="3" />
    </asp:DropDownList>

    <asp:Button ID="btnAltaUsuario" Text="Dar de Alta Usuario" runat="server" OnClick="btnAltaUsuario_Click" CssClass="btn btn-success" />

</asp:Content>
