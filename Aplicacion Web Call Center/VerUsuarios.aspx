<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="Aplicacion_Web_Call_Center.VerUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <h2>Listado de Usuarios</h2>

    <asp:UpdatePanel ID="udpUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="row mb-2">
                <div class="col-6">
                    <div class="d-flex align-items-center">
                        <asp:Label Text="Filtrar: " ID="lblFiltrar" runat="server" class="me-2" />
                        <asp:TextBox ID="txtFiltro" AutoPostBack="true" CssClass="form-control"
                            OnTextChanged="txtFiltro_TextChanged" runat="server" />
                    </div>

                    </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-2">
                        <asp:CheckBox Text="Filtrar por ID" CssClass="" ID="ckbFiltrarId"
                            OnCheckedChanged="ckbFiltrarId_CheckedChanged" AutoPostBack="true" runat="server" />
                    </div>
                </div>
            </div>

            <% if(FiltrarPorId) { %>
            <div class="row mb-3">
                <div class="col-6 d-flex align-items-center">
                    <asp:Label Text="Ingrese Id: " ID="lblId" runat="server" CssClass="me-2" />
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control me-2" TextMode="Number" Style="width: 80px;" />
                    <asp:Button Text="Filtrar" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger ms-2" Visible="false" />
                </div>
            </div>
            <%} %>

            <asp:GridView ID="dgvListaUsuarios" DataKeyNames="Id" OnSelectedIndexChanged="dgvListaUsuarios_SelectedIndexChanged"
                OnPageIndexChanging="dgvListaUsuarios_PageIndexChanging" AutoGenerateColumns="false"
                AllowPaging="true" PageSize="6" CssClass="table table-striped" runat="server">

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID Usuario" ReadOnly="true" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                    <asp:BoundField DataField="Correo" HeaderText="Email" />
                    <asp:BoundField DataField="Rol" HeaderText="Rol" />

                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
                </Columns>

            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

