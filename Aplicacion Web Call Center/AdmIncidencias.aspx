 <%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdmIncidencias.aspx.cs" Inherits="Aplicacion_Web_Call_Center.AdmIncidencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h1 class="text-center">Administrar Incidencias</h1>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtId" class="form-label">ID Incidencia</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtCliente" class="form-label">Cliente</label>
                    <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtTipo" class="form-label">Tipo de Incidencia</label>
                    <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtPrioridad" class="form-label">Prioridad</label>
                    <asp:TextBox ID="txtPrioridad" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtEstado" class="form-label">Estado</label>
                    <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtFechaCreacion" class="form-label">Fecha de Creación</label>
                    <asp:TextBox ID="txtFechaCreacion" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtUsuarioCreador" class="form-label">Usuario Creador</label>
                    <asp:TextBox ID="txtUsuarioCreador" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtUsuarioAsignado" class="form-label">Usuario Asignado</label>
                    <asp:TextBox ID="txtUsuarioAsignado" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtProblematica" class="form-label">Problemática</label>
                    <asp:TextBox ID="txtProblematica" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                </div>
            </div>

            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtComentarioFinal" class="form-label">Comentario de cierre</label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                </div>
            </div>
        </div>

        <div class="row text-center mt-4">
            <div class="col-md-3">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary w-100" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnResolver" runat="server" Text="Resolver" CssClass="btn btn-primary w-100" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="btn btn-primary w-100" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-primary w-100" />
            </div>
        </div>
    </div>

</asp:Content>
