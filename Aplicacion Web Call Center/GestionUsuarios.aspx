<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="Aplicacion_Web_Call_Center.GestionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <h2>Gestión de Usuarios</h2>

            <div class="form-group mb-3">
                <asp:Label ID="lblNombre" Text="Nombre del Usuario" runat="server" CssClass="form-label" />
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator
                    ID="rfvNombre"
                    ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es requerido"
                    CssClass="text-danger ms-2"
                    runat="server" />
            </div>

            <div class="form-group mb-3">
                <asp:Label ID="lblEmail" Text="Email del Usuario" runat="server" CssClass="form-label" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator
                    ID="rfvEmail"
                    ControlToValidate="txtEmail"
                    ErrorMessage="El email es requerido"
                    CssClass="text-danger ms-2"
                    runat="server" />
                <asp:RegularExpressionValidator
                    ID="revEmail"
                    ControlToValidate="txtEmail"
                    ValidationExpression="^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"
                    ErrorMessage="Por favor, ingresa un correo electrónico válido"
                    CssClass="text-danger ms-2"
                    runat="server" />
            </div>

            <asp:Label ID="lblRolUsuario" Text="Rol del Usuario" runat="server" />
            <asp:DropDownList ID="ddlRolUsuario" runat="server" CssClass="form-control margen-inf">
                <asp:ListItem Text="Administrador" Value="1" />
                <asp:ListItem Text="Telefonista" Value="2" />
                <asp:ListItem Text="Supervisor" Value="3" />
            </asp:DropDownList>

            <div class="form-group mb-3">
                <asp:Button ID="btnAltaUsuario" Text="Dar de Alta Usuario" runat="server" OnClick="btnAltaUsuario_Click" CssClass="btn btn-success me-2" />
                <a href="Home.aspx" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
