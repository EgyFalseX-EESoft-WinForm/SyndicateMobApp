<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.master" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="SyndicateServiceLibWeb.Import.EditUsers" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" KeyFieldName="user_id" EnableTheming="True" Theme="Moderno" Width="100%">
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" ShowClearFilterButton="True">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="user_id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_name" VisibleIndex="2" Caption="User name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_pass" VisibleIndex="3" Caption="Password">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FullName" VisibleIndex="6" Caption="Full Name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Mobile" VisibleIndex="7" Caption="Mobile">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Syndicate" FieldName="syndicateId" ShowInCustomizationForm="True" VisibleIndex="4">
                <PropertiesComboBox DataSourceID="SqlDataSourceSyn" TextField="Syndicate" ValueField="SyndicateId">
                    <Columns>
                        <dx:ListBoxColumn Caption="Syndicate" FieldName="Syndicate">
                        </dx:ListBoxColumn>
                    </Columns>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Subcommitte" FieldName="subCommitteId" ShowInCustomizationForm="True" VisibleIndex="5">
                <PropertiesComboBox DataSourceID="SqlDataSourceSub" TextField="SubCommitte" ValueField="SubCommitteId">
                    <Columns>
                        <dx:ListBoxColumn Caption="SubCommitte" FieldName="SubCommitte">
                        </dx:ListBoxColumn>
                    </Columns>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="<%$ ConnectionStrings:ETSMOBILEConnectionString %>" SelectCommand="SELECT [user_id], [user_name], [user_pass], [syndicateId], [subCommitteId], [FullName], [Mobile] FROM [user]" DeleteCommand="DELETE FROM [user] WHERE [user_id] = @user_id" InsertCommand="INSERT INTO [user] ([user_name], [user_pass], [syndicateId], [subCommitteId], [FullName], [Mobile]) VALUES (@user_name, @user_pass, @syndicateId, @subCommitteId, @FullName, @Mobile)" UpdateCommand="UPDATE [user] SET [user_name] = @user_name, [user_pass] = @user_pass, [syndicateId] = @syndicateId, [subCommitteId] = @subCommitteId, [FullName] = @FullName, [Mobile] = @Mobile WHERE [user_id] = @user_id">
        <DeleteParameters>
            <asp:Parameter Name="user_id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="user_name" Type="String" />
            <asp:Parameter Name="user_pass" Type="String" />
            <asp:Parameter Name="syndicateId" Type="Int32" />
            <asp:Parameter Name="subCommitteId" Type="Int32" />
            <asp:Parameter Name="FullName" Type="String" />
            <asp:Parameter Name="Mobile" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="user_name" Type="String" />
            <asp:Parameter Name="user_pass" Type="String" />
            <asp:Parameter Name="syndicateId" Type="Int32" />
            <asp:Parameter Name="subCommitteId" Type="Int32" />
            <asp:Parameter Name="FullName" Type="String" />
            <asp:Parameter Name="Mobile" Type="String" />
            <asp:Parameter Name="user_id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSyn" runat="server" ConnectionString="<%$ ConnectionStrings:ETSMOBILEConnectionString %>" SelectCommand="SELECT [SyndicateId], [Syndicate] FROM [CDSyndicate]" >
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSub" runat="server" ConnectionString="<%$ ConnectionStrings:ETSMOBILEConnectionString %>" SelectCommand="SELECT [SubCommitteId], [SubCommitte] FROM [CDSubCommitte]" >
    </asp:SqlDataSource>
</asp:Content>


