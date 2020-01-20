<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlbumsAdmin.aspx.cs" Inherits="AlbumsAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/Theme1/admin.css" rel="stylesheet" 
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <!--Header -->
        <div id="header">
            <h2>夢想家電子相簿</h2>
            <div id="home">
                <a href="../Albums.aspx" >《首頁》</a>
                <a href="PhotoUpload.aspx" >|《相片上載》</a>
                <a>
                <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="loginStatus" 
                    LoginText="|《登入》" LogoutText="|《登出》" 
                    onloggedout="LoginStatus1_LoggedOut" /></a>
            </div>
        </div>
        <!--Content-->
        <div id="content">
            <div id="content-inside">
                <!--MenuBar-->
                <div id="MenuBar">
                    <asp:ImageButton ID="btnEdit" runat="server" 
                        ImageUrl="../Images/EditButton.png" onclick="btnEdit_Click" />
                    <asp:ImageButton ID="btnInsert" runat="server" 
                        ImageUrl="../Images/insertButton.png" onclick="btnInsert_Click" />
                    <asp:ImageButton ID="btnEditPhotos" runat="server" 
                        ImageUrl="~/Images/bntPhotos.png" onclick="btnEditPhotos_Click" />
                </div>

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <!--master-->
                
                <asp:GridView ID="gvAlbums" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" DataKeyNames="AlbumID" DataSourceID="sqlAlbums" 
                    EmptyDataText="沒有資料錄可顯示。" Font-Size="10pt" ForeColor="Black" 
                    onrowdeleting="gvAlbums_RowDeleting" Width="700px" 
                    onrowdeleted="gvAlbums_RowDeleted">
                    <RowStyle Wrap="True" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                            ButtonType="Button" />
                        <asp:BoundField DataField="AlbumID" HeaderText="編號" InsertVisible="False" 
                            ReadOnly="True" SortExpression="AlbumID">
                        </asp:BoundField>
                        <asp:BoundField DataField="AlbumName" HeaderText="相簿名稱" 
                            SortExpression="AlbumName" />
                        <asp:BoundField DataField="AlbumDesc" HeaderText="相簿說明" 
                            SortExpression="AlbumDesc" />
                        <asp:CheckBoxField DataField="Protection" HeaderText="保護" 
                            SortExpression="Protection" />
                        <asp:BoundField DataField="Password" HeaderText="密碼" 
                            SortExpression="Password" />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
                
                <asp:Image ID="Settings" runat="server" ImageUrl="../Images/AlbumSettings.png" 
                    Height="156px" Width="176px" />
                <asp:SqlDataSource ID="sqlAlbums" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                    DeleteCommand="DELETE FROM [AlbumData] WHERE [AlbumID] = @AlbumID" 
                    InsertCommand="INSERT INTO [AlbumData] ([AlbumName], [AlbumDesc], [Protection], [Password]) VALUES (@AlbumName, @AlbumDesc, @Protection, @Password)" 
                    ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>" 
                    SelectCommand="SELECT [AlbumID], [AlbumName], [AlbumDesc], [Protection], [Password] FROM [AlbumData]" 
                    
                    UpdateCommand="UPDATE [AlbumData] SET [AlbumName] = @AlbumName, [AlbumDesc] = @AlbumDesc, [Protection] = @Protection, [Password] = @Password WHERE [AlbumID] = @AlbumID">
                    <DeleteParameters>
                        <asp:Parameter Name="AlbumID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="AlbumName" Type="String" />
                        <asp:Parameter Name="AlbumDesc" Type="String" />
                        <asp:Parameter Name="Protection" Type="Boolean" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="AlbumID" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="AlbumName" Type="String" />
                        <asp:Parameter Name="AlbumDesc" Type="String" />
                        <asp:Parameter Name="Protection" Type="Boolean" />
                        <asp:Parameter Name="Password" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <!--detail-->
                <table ID="detail">
                    <tr>
                        <td class="tblHeader" colspan="2">
                            新增相簿資料</td>
                    </tr>
                    <tr>
                        <td class="column1">
                            相簿名稱</td>
                        <td class="column2">
                            <asp:TextBox ID="txtAlbumName" runat="server" MaxLength="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            相簿說明</td>
                        <td class="column2">
                            <asp:TextBox ID="txtAlbumDesc" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            保護相簿</td>
                        <td>
                            <asp:CheckBox ID="cbxProtection" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            相簿密碼</td>
                        <td class="column2">
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tblFooter" class="column1" colspan="2">
                            <asp:Button ID="btnInsertDetail" runat="server" onclick="btnInsertDetail_Click" 
                                Text="新增相簿" Width="100px" />
                        </td>
                    </tr>
                </table>
                <asp:Image ID="InsertDetail" runat="server" ImageUrl="../Images/InsertData.png" Height="156px" Width="176px"/>
                <asp:SqlDataSource ID="sqlDetail" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                    InsertCommand="INSERT INTO [AlbumData] ([AlbumName], [AlbumDesc], [Protection], [Password]) VALUES (@paramAlbumName, @paramAlbumDesc, @paramProtection, @paramPassword)" 
                    ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>">
                    <InsertParameters>
                        <asp:ControlParameter ControlID="txtAlbumName" Name="paramAlbumName" 
                            PropertyName="Text" />
                        <asp:ControlParameter ControlID="txtAlbumDesc" Name="paramAlbumDesc" 
                            PropertyName="Text" />
                        <asp:ControlParameter ControlID="cbxProtection" Name="paramProtection" 
                            PropertyName="Checked" />
                        <asp:ControlParameter ControlID="txtPassword" Name="paramPassword" 
                            PropertyName="Text" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </asp:View>
            <asp:View ID="View3" runat="server">
                請選擇相簿：<asp:DropDownList ID="dwnAlbum" runat="server" 
                    AppendDataBoundItems="True" DataSourceID="sqlAlbum" DataTextField="AlbumName" 
                    DataValueField="AlbumID" Height="25px" Width="170px" AutoPostBack="True">
                    <asp:ListItem Value="0">===請選擇相簿===</asp:ListItem>
                </asp:DropDownList><br /><br />
                <asp:GridView ID="gvPhotos" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                    DataKeyNames="PhotoGUID" DataSourceID="sqlPhotos" Font-Size="10pt" 
                    ForeColor="#333333">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                            ShowEditButton="True" >
                        <ItemStyle Width="150px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="AlbumID" HeaderText="相簿編號" 
                            SortExpression="AlbumID" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="相片說明" SortExpression="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" MaxLength="6" 
                                    Text='<%# Bind("Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="FileName" HeaderText="檔案名稱" 
                            SortExpression="FileName" ReadOnly="True" >
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField='PhotoGUID' 
                            DataImageUrlFormatString="~/Photos/{0}"  ItemStyle-Width="50" 
                            HeaderText="縮圖" ReadOnly="True">
                            <ControlStyle Height="50px" Width="50px" />
                            <ItemStyle Width="50px" />
                        </asp:ImageField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>  
                <asp:SqlDataSource ID="sqlAlbum" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                    SelectCommand="SELECT [AlbumID], [AlbumName] FROM [AlbumData]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlPhotos" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                    DeleteCommand="DELETE FROM [PhotoData] WHERE [PhotoGUID] = @PhotoGUID" 
                    InsertCommand="INSERT INTO [PhotoData] ([AlbumID], [Description], [FileName], [PhotoGUID]) VALUES (@AlbumID, @Description, @FileName, @PhotoGUID)" 
                    SelectCommand="SELECT [AlbumID], [Description], [FileName], [PhotoGUID] FROM [PhotoData] where AlbumID=@paramAlbumID order by UploadTime" 
                    
                    UpdateCommand="UPDATE [PhotoData] SET [AlbumID] = @AlbumID, [Description] = @Description, [FileName] = @FileName WHERE [PhotoGUID] = @PhotoGUID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dwnAlbum" Name="paramAlbumID" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="PhotoGUID" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="AlbumID" Type="Int32" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="FileName" Type="String" />
                        <asp:Parameter Name="PhotoGUID" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="AlbumID" Type="Int32" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="FileName" Type="String" />
                        <asp:Parameter Name="PhotoGUID" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </asp:View>
        </asp:MultiView>            
            </div>
            <br />
        </div>
        <!--Footer-->
        <div id="footer">
            <div>
                DotNet開發聖殿製作
                   </div>
            
 
    </div>
    </form>
</body>
</html>
