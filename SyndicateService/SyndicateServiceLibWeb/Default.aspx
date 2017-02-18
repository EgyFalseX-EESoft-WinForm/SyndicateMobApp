<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Default.aspx.cs" Inherits="SyndicateServiceLibWeb._Default" %>


<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" style="width: 100px">
        <tr>
            <td style="text-align: center">
                <asp:Image ID="Image1" runat="server" Height="256px" ImageUrl="~/Content/Images/Logo.png" Width="256px" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Andalus" Font-Size="XX-Large" Text="Wellcome back ...!!"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>