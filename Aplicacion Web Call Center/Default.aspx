<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aplicacion_Web_Call_Center.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Inicio de Sesión</h2>
    <p>Por favor, ingrese sus credenciales para acceder al sistema.</p>

    <div class="form-group">
        <label for="txtUsername">Usuario</label>
        <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <label for="txtPassword">Contraseña</label>
        <asp:TextBox ID="txtPassword" CssClass="form-control margen-inf" TextMode="Password" runat="server" />
    </div>
    <asp:Button ID="btnLogin" Text="Iniciar Sesión" CssClass="btn btn-primary" runat="server" OnClick="btnLogin_Click" />
    
    <asp:Label ID="lblErrorMessage" CssClass="text-danger" runat="server" Visible="false" />

</asp:Content>
