<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Dottor.WebFormApplication.Web.Cities.List" %>
<asp:Content ID="cphMain" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:ListView runat="server" ItemType="Dottor.MicrosoftIgnite.Data.Models.TourCity" ID="lvCities">
        <ItemTemplate>
            <tr>
                <td>
                    <a href="Edit?id=<%#: Item.Id %>">edit</a>
                </td>
                <td><%#: Item.TourRegionId %></td>
                <td><%#: Item.Name %></td>
                <td><%#: Item.DateDisplayed %></td>
                <td><%#: Item.Visible %></td>
                <td><%#: Item.LastUpdateDate %></td>
                <td><%#: Item.LastUpdateUserName %></td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table class="table">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">&nbsp;</th>
                        <th scope="col">Region</th>
                        <th scope="col">City</th>
                        <th scope="col">Data</th>
                        <th scope="col">Visible</th>
                        <th scope="col">Date last update</th>
                        <th scope="col">User last update</th>
                    </tr>
                </thead>
                <tbody>
                    <tr runat="server" id="itemPlaceholder" />
                </tbody>
            </table>
        </LayoutTemplate>
    </asp:ListView>

</asp:Content>
