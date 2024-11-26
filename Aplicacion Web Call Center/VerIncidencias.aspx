<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerIncidencias.aspx.cs" Inherits="Aplicacion_Web_Call_Center.VerIncidencias" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <h2>Incidencias</h2>

    <%--    rrrr--%>

    <asp:UpdatePanel ID="udpUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="row mb-2">
                <div class="col-6">
                    <div class="d-flex align-items-center">
                        <asp:Label Text="Filtrar: " ID="lblFiltrar" runat="server" class="me-2" />
                        <asp:TextBox ID="tbxFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="tbxFiltro_TextChanged" runat="server" />
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-2">
                        <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="cbxFiltroAvanzado"
                            AutoPostBack="true" OnCheckedChanged="cbxFiltroAvanzado_CheckedChanged" runat="server" />
                    </div>
                </div>
            </div>

            <%if (FiltroAvanzado)
                {%>
            <div class="row mb-3">

                <div class="col-3">
                    <div class="mb-2">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                        <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Número" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-2">
                        <asp:Label Text="Criterio" ID="lblCriterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-2">
                        <asp:Label Text="Filtro" ID="lblFiltro" runat="server" />
                        <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server" />
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-2">
                        <asp:Label Text="Estado" ID="lblEstado" runat="server" />
                        <asp:DropDownList CssClass="form-control" ID="ddlEstado" runat="server">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activos" />
                            <asp:ListItem Text="Inactivos" />
                        </asp:DropDownList>
                    </div>
                </div>

            </div>

            <div class="row mb-3">
                <div class="col-3">
                    <div class="mb-2">
                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
                    </div>
                </div>
            </div>
            <%} %>


            <%--    rrrr--%>

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
                    <asp:BoundField DataField="UsuarioAsignado.NombreUsuario" HeaderText="Usuario Asignado" />

                    <asp:TemplateField HeaderText="Rol">
                        <ItemTemplate>
                            <%# (int)Eval("UsuarioAsignado.Rol") == 1 ? "Administrador" : 
                                (int)Eval("UsuarioAsignado.Rol") == 2 ? "Telefonista" : 
                                                                                "Supervisor" %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowSelectButton="true" SelectText="Asignar" HeaderText="Acción" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
