<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerIncidencias.aspx.cs" Inherits="Aplicacion_Web_Call_Center.VerIncidencias" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <h2>Incidencias</h2>

    <asp:UpdatePanel ID="udpUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="row mb-2">
                <div class="col-3">
                    <div>
                        <asp:Label Text="Filtrar por Cliente: " ID="lblFiltrar" runat="server" class="me-2" />
                        <asp:TextBox ID="tbxFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="tbxFiltro_TextChanged" runat="server" />
                    </div>
                </div>
                <div class="col-3">
                    <div>
                        <asp:Label Text="Filtrar por Usuario: " ID="lblFiltrarU" runat="server" class="me-2" />
                        <asp:TextBox ID="txtFiltroU" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltroU_TextChanged" runat="server" />
                    </div>
                </div>
                <div class="col-2">
                    <div>
                        <asp:Label Text=" " ID="Label1" runat="server" />
                        <asp:Button Text="Limpiar Filtros" ID="btnLimpiarFiltros" CssClass="btn btn-primary"
                            OnClick="btnLimpiarFiltros_Click" runat="server" />
                    </div>
                </div>
                <div class="col-2">
                    <div>
                        <asp:Label Text=" " ID="Label2" runat="server" />
                        <asp:CheckBox Text="Más filtros" CssClass="form-check" ID="cbxFiltroAvanzado"
                            AutoPostBack="true" OnCheckedChanged="cbxFiltroAvanzado_CheckedChanged" runat="server" />
                    </div>
                </div>
            </div>

            <%if (FiltroAvanzado)
                {%>
            <div class="row mb-3">

                <div class="col-3">
                    <div class="mb-2">
                        <asp:Label Text="Tipo de Incidencia" ID="lblTipoInci" runat="server" />
                        <asp:DropDownList ID="ddlTiposIncidencia" AutoPostBack="true" CssClass="form-select form-select-sm mb-3 rounded-pill shadow-sm"
                            OnSelectedIndexChanged="ddlTiposIncidencia_SelectedIndexChanged" runat="server">
                            <asp:ListItem Text="Filtrar por" Value="" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-2">
                        <asp:Label Text="Prioridad" ID="lblPrioridad" runat="server" />
                        <asp:DropDownList ID="ddlPrioridad" AutoPostBack="true" CssClass="form-select form-select-sm mb-3 rounded-pill shadow-sm"
                            OnSelectedIndexChanged="ddlPrioridad_SelectedIndexChanged" runat="server">
                            <asp:ListItem Text="Filtrar por" Value="" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-2">
                        <asp:Label Text="Estado" ID="lblEstado" runat="server" />
                        <asp:DropDownList ID="ddlEstado" AutoPostBack="true" CssClass="form-select form-select-sm mb-3 rounded-pill shadow-sm"
                            OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" runat="server">
                            <asp:ListItem Text="Filtrar por" Value="" />
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-2">
                        <asp:Label Text="Rol" ID="lblRol" runat="server" />
                        <asp:DropDownList CssClass="form-select form-select-sm mb-3 rounded-pill shadow-sm"
                            ID="ddlRol" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged"
                            AutoPostBack="true" runat="server">
                            <asp:ListItem Text="Administrador" />
                            <asp:ListItem Text="Telefonista" />
                            <asp:ListItem Text="Supervisor" />
                        </asp:DropDownList>
                    </div>
                </div>

            </div>

            <%} %>

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
                    <asp:BoundField DataField="UsuarioAsignado.Id" HeaderText="Id de Usuario"  />     

                    <asp:TemplateField HeaderText="Rol">
                        <ItemTemplate>
                            <%# (int)Eval("UsuarioAsignado.Rol") == 1 ? "Administrador" : 
                                (int)Eval("UsuarioAsignado.Rol") == 2 ? "Telefonista" : 
                                                                                "Supervisor" %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowSelectButton="true" SelectText="Reasignar" HeaderText="Acción" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
