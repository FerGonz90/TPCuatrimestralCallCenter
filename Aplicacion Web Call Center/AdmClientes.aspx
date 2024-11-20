<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdmClientes.aspx.cs" Inherits="Aplicacion_Web_Call_Center.AdmClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Listado de Clientes</h2>

    <asp:GridView ID="dgvClientes" DataKeyNames="Id" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
         
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Cliente" ReadOnly="true" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
            <asp:CommandField ShowSelectButton="true" SelectText="Administrar" HeaderText="Acción" />

        </Columns>
    </asp:GridView>

</asp:Content>
