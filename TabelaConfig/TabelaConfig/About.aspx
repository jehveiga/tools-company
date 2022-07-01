<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TabelaConfig.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Aqui vai ser a tabela</h3>

    <asp:Button ID="BtnAcessaSite" runat="server" class="btn btn-outline-success" Text="Acessar" OnClick="BtnAcessaSite_Click"/>


    <asp:Table ID="TbPrecos" runat="server" class="table table-bordered table-primary">
    </asp:Table>

</asp:Content>
