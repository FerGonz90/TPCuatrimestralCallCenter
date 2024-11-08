<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionClientes.aspx.cs" Inherits="Aplicacion_Web_Call_Center.GestionClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Gestión de Clientes</h2>

    <asp:Label ID="lblNombre" Text="Nombre del Cliente" runat="server" />
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />

    <asp:Label ID="lblEmail" Text="Email del Cliente" runat="server" />
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control margen-inf" />

    <asp:Button ID="btnAltaCliente" Text="Dar de Alta Cliente" runat="server" OnClick="btnAltaCliente_Click" CssClass="btn btn-success" />

</asp:Content>
