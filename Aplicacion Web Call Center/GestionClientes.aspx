<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionClientes.aspx.cs" Inherits="Aplicacion_Web_Call_Center.GestionClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <div class="col-6">
            <h2>Gestión de Clientes</h2>

            <div class="form-group mb-2 row">
                <asp:Label ID="lblNombre" Text="Nombre del Cliente" runat="server" CssClass="form-label" />
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator 
                    ID="rfvNombreCliente" 
                    ControlToValidate="txtNombre" 
                    ErrorMessage="El nombre es requerido" 
                    CssClass="text-danger ms-2" 
                    runat="server" />
            </div>

            <div class="form-group mb-2 row">
                <asp:Label ID="lblEmail" Text="Email del Cliente" runat="server" CssClass="form-label" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control margen-inf" />
                <asp:RequiredFieldValidator 
                    ID="rfvEmailCliente" 
                    ControlToValidate="txtEmail" 
                    ErrorMessage="El email es requerido" 
                    CssClass="text-danger ms-2" 
                    runat="server" />
            </div>

            <div class="form-group mb-2 row">
                <asp:Label ID="lblTelefono" Text="Teléfono del Cliente" runat="server" CssClass="form-label" />
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator 
                    ID="rfvTelefonoCliente" 
                    ControlToValidate="txtTelefono" 
                    ErrorMessage="El teléfono es requerido" 
                    CssClass="text-danger ms-2" 
                    runat="server" />
            </div>

            <div class="form-group mb-2">
                <asp:Button ID="btnAltaCliente" Text="Dar de Alta Cliente" runat="server" OnClick="btnAltaCliente_Click" CssClass="btn btn-success me-2" />
                <a href="Home.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
