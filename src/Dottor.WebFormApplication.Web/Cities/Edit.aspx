<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Dottor.WebFormApplication.Web.Cities.Edit" %>

<asp:Content ID="cphMain" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Modifica città/evento</h2>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="txtName">Nome</asp:Label>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="*" CssClass="text-danger"/>
        <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="txtDateDisplayed">Data visualizzata</asp:Label>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDateDisplayed" ErrorMessage="*" CssClass="text-danger" />
        <asp:TextBox runat="server" ID="txtDateDisplayed" CssClass="form-control" />
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="dtDate">Data inizio evento</asp:Label>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="dtDate" ErrorMessage="*" CssClass="text-danger" />
        <dx:ASPxDateEdit runat="server" ID="dtDate" CssClass="form-control">
            <ClientSideEvents KeyDown="function(s, e) {
        if (e.htmlEvent.KeyCode == ASPxKey.Enter)
            s.HideDropDown();
    }" GotFocus="function(s, e) {
        s.ShowDropDown();
    }" />
        </dx:ASPxDateEdit>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="ddlRegion">Zona</asp:Label>
        <asp:DropDownList runat="server" ID="ddlRegion" CssClass="form-control" DataValueField="Id" DataTextField="Name" />
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="txtImage">Url immagine</asp:Label>
        <asp:TextBox runat="server" ID="txtImage" CssClass="form-control" />
    </div>
    <div class="form-check">
        <asp:CheckBox runat="server" ID="cbVisible" Checked="true" />
        <asp:Label runat="server" AssociatedControlID="cbVisible">Visibile</asp:Label>
        
    </div>

    <asp:Button runat="server" ID="btnInsert" Text="Salva" OnClick="btnInsert_Click" />
</asp:Content>
