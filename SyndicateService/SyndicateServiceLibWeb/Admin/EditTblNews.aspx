<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="EditTblNews.aspx.cs" Inherits="SyndicateServiceLibWeb.Import.EditTblNews" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="ASPxGridViewMain" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMain" EnableTheming="True" KeyFieldName="news_id" Theme="Moderno" OnStartRowEditing="ASPxGridViewMain_StartRowEditing" Width="100%">
        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="True">
            <AdaptiveDetailLayoutProperties>
                <Items>
                    <dx:GridViewColumnLayoutItem>
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="news_id">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="subject">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="image_path">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="contain">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="news_date">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="user_in">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="date_in">
                    </dx:GridViewColumnLayoutItem>
                </Items>
            </AdaptiveDetailLayoutProperties>
        </SettingsAdaptivity>
        <SettingsPager PageSize="20">
        </SettingsPager>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="subject">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="news_date">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="contain" RowSpan="2">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="image_path">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="news_id" ShowInCustomizationForm="True" VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Subject" FieldName="subject" ShowInCustomizationForm="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Date" FieldName="news_date" ShowInCustomizationForm="True" VisibleIndex="5">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn Caption="User" FieldName="user_in" ShowInCustomizationForm="True" VisibleIndex="6" ReadOnly="True">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="date_in" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="7" Caption="Date">
                <PropertiesDateEdit DisplayFormatString="d/M/yyyy" EditFormat="Custom" EditFormatString="d/M/yyyy">
                </PropertiesDateEdit>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" ShowApplyFilterButton="True">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataMemoColumn Caption="Contain" FieldName="contain" ShowInCustomizationForm="True" VisibleIndex="4">
            </dx:GridViewDataMemoColumn>
            <dx:GridViewDataImageColumn Caption="Image Path" FieldName="image_path" ShowInCustomizationForm="True" VisibleIndex="3">
                <EditItemTemplate>
                    <dx:ASPxUploadControl ID="ASPxUploadControlImagePath" runat="server" EnableTheming="True" OnFileUploadComplete="ASPxUploadControlImagePath_FileUploadComplete" ShowProgressPanel="True" ShowUploadButton="True" Theme="Moderno" UploadMode="Auto" UploadStorage="FileSystem" Width="280px">
                        <FileSystemSettings UploadFolder="~/NewsFiles/" />
                    </dx:ASPxUploadControl>
                    <asp:HiddenField ID="HiddenFieldImagePath" runat="server" ClientIDMode="Static" Value='<%# Bind("image_path", "{0}") %>' />
                </EditItemTemplate>
            </dx:GridViewDataImageColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSourceMain" runat="server" ConnectionString="<%$ ConnectionStrings:ETSMOBILEConnectionString %>" SelectCommand="SELECT [news_id], [subject], [image_path], [contain], [news_date], [user_in], [date_in] FROM [TblNews]" DeleteCommand="DELETE FROM [TblNews] WHERE [news_id] = @news_id" InsertCommand="INSERT INTO [TblNews] ([subject], [image_path], [contain], [news_date], [user_in], [date_in]) VALUES (@subject, @image_path, @contain, @news_date, @user_in, GETDATE())" OnInserting="SqlDataSourceMain_Inserting" OnUpdating="SqlDataSourceMain_Updating" UpdateCommand="UPDATE [TblNews] SET [subject] = @subject, [image_path] = @image_path, [contain] = @contain, [news_date] = @news_date, [user_in] = @user_in, [date_in] = GETDATE() WHERE [news_id] = @news_id">
        <DeleteParameters>
            <asp:Parameter Name="news_id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="subject" Type="String" />
            <asp:Parameter Name="image_path" Type="String" />
            <asp:Parameter Name="contain" Type="String" />
            <asp:Parameter Name="news_date" Type="DateTime" />
            <asp:Parameter Name="user_in" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="subject" Type="String" />
            <asp:Parameter Name="image_path" Type="String" />
            <asp:Parameter Name="contain" Type="String" />
            <asp:Parameter Name="news_date" Type="DateTime" />
            <asp:Parameter Name="user_in" Type="Int32" />
            <asp:Parameter Name="news_id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>


