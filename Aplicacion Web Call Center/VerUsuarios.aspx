<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="Aplicacion_Web_Call_Center.VerUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Usuarios</h2>

    <asp:GridView ID="dgvUsuarios" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" runat="server" AllowPaging="True" 
        PageSize="6" OnPageIndexChanging="dgvUsuarios_PageIndexChanging" 
        AutoGenerateColumns="False" CssClass="table table-striped">

        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Usuario" ReadOnly="true" />
            <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
            <asp:BoundField DataField="Correo" HeaderText="Correo Electrónico" />
            <asp:BoundField DataField="Rol" HeaderText="Rol" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
        </Columns>
    </asp:GridView>

</asp:Content>
