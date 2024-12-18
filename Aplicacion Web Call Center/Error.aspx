﻿<%@ Page Title="Error" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Aplicacion_Web_Call_Center.Error" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Contenido/estilos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container error-container">
        <div class="error-box">
            <h1>¡Ups! 😥</h1>
            <p>Algo salió mal. Por favor, intenta nuevamente más tarde.</p>
            <p><strong>Detalle del error: </strong></p>
            <asp:Label ID="lblDetalleError" runat="server" CssClass="text-danger"></asp:Label>
            <div class="btn-home">
                <%if (Session["usuario"] != null) { %>
                <a href="Home.aspx" class="btn btn-primary">Volver al inicio</a>
                <%} %>
                <%else { %>
                <a href="Default.aspx" class="btn btn-primary">Volver al inicio</a>
                <%}%>
            </div>
        </div>
    </div>
</asp:Content>

