<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Dottor.WebFormApplication.Web.Cities.List" %>
<asp:Content ID="cphMain" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Insert" class="btn btn-primary">Crea nuovo evento</a>
    
    <br /><br />

    <asp:ListView runat="server" ItemType="Dottor.MicrosoftIgnite.Data.Models.TourCity" ID="lvCities">
        <ItemTemplate>
            <tr>
                <td>
                    <a href="Edit?id=<%#: Item.Id %>">edit</a>
                </td>
                <td><%#: Item.Name %></td>
                <td><%#: Item.DateDisplayed %></td>
                <td><%# Item.Visible ? "<input type='checkbox' checked='checked' disabled />" : "" %></td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table class="table">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">&nbsp;</th>
                        <th scope="col">City</th>
                        <th scope="col">Data</th>
                        <th scope="col">Visible</th>
                    </tr>
                </thead>
                <tbody>
                    <tr runat="server" id="itemPlaceholder" />
                </tbody>
            </table>
        </LayoutTemplate>
    </asp:ListView>

</asp:Content>
