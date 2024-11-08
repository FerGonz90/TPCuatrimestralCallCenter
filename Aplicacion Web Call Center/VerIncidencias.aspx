<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerIncidencias.aspx.cs" Inherits="Aplicacion_Web_Call_Center.VerIncidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Incidencias</h2>

<asp:GridView ID="dgvIncidencias" DataKeyNames="Id" OnSelectedIndexChanged="dgvIncidencias_SelectedIndexChanged" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
     
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID Incidencia" ReadOnly="true" />
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
        <asp:BoundField DataField="TipoIncidencia" HeaderText="Tipo de Incidencia" />
        <asp:BoundField DataField="PrioridadIncidencia" HeaderText="Prioridad" />
        <asp:BoundField DataField="Estado" HeaderText="Estado" />
        <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Acción" />

    </Columns>
</asp:GridView>

</asp:Content>
