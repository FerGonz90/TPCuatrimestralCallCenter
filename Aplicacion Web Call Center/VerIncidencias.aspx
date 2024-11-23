<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerIncidencias.aspx.cs" Inherits="Aplicacion_Web_Call_Center.VerIncidencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Incidencias</h2>

    <asp:GridView ID="dgvIncidencias" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvIncidencias_SelectedIndexChanged" runat="server" AllowPaging="True" 
        PageSize="6" OnPageIndexChanging="dgvIncidencias_PageIndexChanging" 
        AutoGenerateColumns="False" CssClass="table table-striped">

        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Incidencia" ReadOnly="true" />
            <asp:BoundField DataField="Cliente.Nombre" HeaderText="Cliente" />
            <asp:BoundField DataField="Tipo.Descripcion" HeaderText="Tipo de Incidencia" />
            <asp:BoundField DataField="Prioridad.Descripcion" HeaderText="Prioridad" />
            <asp:BoundField DataField="Estado.Descripcion" HeaderText="Estado" />
            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación"
                DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
            <asp:CommandField ShowSelectButton="true" SelectText="Asignar" HeaderText="Acción" />
        </Columns>
    </asp:GridView>

</asp:Content>
