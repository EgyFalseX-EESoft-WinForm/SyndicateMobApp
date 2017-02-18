<%@ Page Title="" Language="C#" MasterPageFile="~/Light.master" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="SyndicateServiceLibWeb.Download.Download" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayoutMain" runat="server" ShowItemCaptionColon="False">
        <Items>
            <dx:LayoutGroup Caption="Download Versions" GroupBoxDecoration="Box" HorizontalAlign="Center" VerticalAlign="Top">
                <Items>
                     <dx:LayoutItem Caption="Android version   ">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxHyperLink ID="AndroidLink" runat="server" ImageUrl="~/Content/Images/android_logo32.png" Text="Download Android Version" NavigateUrl="~/Download/Files/TeacherUnionSyndicate.Droid-Signed.apk" >
                        </dx:ASPxHyperLink>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="IOS version         ">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxHyperLink ID="IOSLink" runat="server" ImageUrl="~/Content/Images/ios_logo32.png" Text="Download IOS Version" >
                        </dx:ASPxHyperLink>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Windows 10 version">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxHyperLink ID="Windows10Link" runat="server" ImageUrl="~/Content/Images/windows_10_logo32.png" Text="Download Windos 10 Version" NavigateUrl="~/Download/Files/SyndicateMobApp.UWP.zip" >
                        </dx:ASPxHyperLink>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
        <SettingsItemCaptions VerticalAlign="Middle" />
        <SettingsItems HorizontalAlign="Center" VerticalAlign="Middle" />
    </dx:ASPxFormLayout>
</asp:Content>
