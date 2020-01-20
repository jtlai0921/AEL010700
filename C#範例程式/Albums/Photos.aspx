<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Photos.aspx.cs" Inherits="Photos" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Theme1/Photos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" >
    <div id="wrapper">
        <!--Header --><div id="header">
            <abbr title="這是以ASP.NET及CSS製作的網路相簿">
                <h1>
                    夢想家電子相簿</h1>
            </abbr>
            <div id="home">
                <a href="Albums.aspx">《首頁》</a> <a href="Admin/AlbumsAdmin.aspx">
                    <asp:Label ID="txtAdmin" runat="server" Text="|《相簿管理》" Visible="False" /></a> <a href="Admin/PhotoUpload.aspx">
                        <asp:Label ID="txtUpload" runat="server" Text="|《相片上載》" 
                    Visible="False" /></a> 
                    <a title="相簿管理者登入">
                            <asp:LoginStatus ID="LoginStatus1" runat="server" 
                    CssClass="loginStatus" LoginText="|《登入》"
                                LogoutText="|《登出》" onloggedout="LoginStatus1_LoggedOut" />
                        </a>
            </div>
        </div>
        <!--Content-->
        <div id="content">
            <div id="content-inside" >
                 <asp:Label ID="txtAlbumName" runat="server" BackColor="#FFFF66" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                        <asp:DataList ID="dlPhotos" runat="server" DataKeyField="AlbumID" DataSourceID="sqlPhotoData"
                            RepeatColumns="5" RepeatDirection="Horizontal" BorderColor="Black" 
                    BorderWidth="1px"  onitemdatabound="dlPhotos_ItemDataBound" 
                     oneditcommand="dlPhotos_EditCommand" 
                     onupdatecommand="dlPhotos_UpdateCommand">
                            <ItemTemplate>
                                <div id="Picture">
                                        <div class="PicBG">
                                            <a href='Browse.aspx?PhotoGUID=<%# Eval("PhotoGUID")%>'>   
                                                <img class="PicThumb" src='photos/<%# Eval("PhotoGUID") %>' />
                                                
                                            </a>
                                        </div>
                                        <asp:Button ID="btnDefault" runat="server" Text="封面" 
                                            CommandArgument='<%# Eval("PhotoGUID")%>' onclick="btnDefault_Click" 
                                            Visible="False" CommandName="setDefaultPic" />  
                                         <asp:Button ID="btnEdit" runat="server" Text="編輯" CommandName="edit" 
                                            Visible="False" />   
                                        <asp:Label ID="Description" runat="server" Text='<%# Eval("Description") %>' />
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                   <div id="Picture">
                                        <div class="PicBG">
                                            <a href='Browse.aspx?PhotoGUID=<%# Eval("PhotoGUID")%>'>                                                
                                                <img class="PicThumb" src='photos/<%# Eval("PhotoGUID") %>' />
                                            </a>
                                        </div>
                                    <asp:Button ID="btnUpdate" runat="server" Text="更新" CommandName="update" CommandArgument='<%# Eval("PhotoGUID")%>'
                                            Visible="true" />                                       
                                    <asp:TextBox ID="txtDesc" runat="server" Text='<%# Bind("Description") %>' Visible="true" Width="100" MaxLength="6" AutoPostBack="True" ></asp:TextBox>
                                </div>
                            </EditItemTemplate>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:DataList>
                <asp:SqlDataSource ID="sqlProtect" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                            onselected="sqlProtect_Selected" 
                      
                    ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>" 
                    SelectCommand="SELECT Top 1 AlbumID FROM AlbumData
                       Where AlbumID=@paramAlbumID and (Protection='False' or Protection is null)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="paramAlbumID" QueryStringField="AlbumID" />
                    </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sqlPhotoData" runat="server" ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>"
                            SelectCommand="with Albums as
                                    (
	                                    select *,
	                                    Row_Number() Over (order by UploadTime) AS 'RowNumber'
	                                    from PhotoData
                                                      where  AlbumID=@paramAlbumID
                                    )

                                    Select PhotoGUID,FileName,AlbumID,Description from Albums where 
                                    RowNumber Between (( @paramPage - 1 ) * 15 + 1)  And (( @paramPage - 1 ) * 15 + 15) "
                            UpdateCommand="UPDATE [PhotoData] SET [Description] = @paramDescription WHERE [PhotoGUID] = @paramPhotoGUID"
                            ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>" 
                            onselected="sqlPhotoData_Selected">
                            
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="" Name="paramAlbumID" QueryStringField="AlbumID" />
                                <asp:QueryStringParameter DbType="Int16" DefaultValue="1" Name="paramPage" QueryStringField="Page" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="paramDescription" DbType="String" Size="6" />
                                <asp:Parameter Name="paramPhotoGUID" DbType="String" Size="255" />
                            </UpdateParameters>
                        </asp:SqlDataSource>

                        <div id="pager">
                            <asp:Panel ID="plPager" runat="server" >
                            </asp:Panel>
                        </div>
                         <div id="NoPhoto">
                            <asp:Image  ImageUrl="~/Images/Close.png" runat="server" ID="imgNo" 
                                Visible="False" ToolTip="無任何照片" /><br />
                            <asp:Literal ID="txtMsg" runat="server" Text="沒有任何照片，請按鈕回上一頁！<br />" Visible="False" />
                            <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Images/UpLevel.png" 
                                ToolTip="回上一頁" Visible="False"  />
                         </div>
            </div>
        </div>
        <!--Footer-->
        <div id="footer">
            <div>
                DotNet開發聖殿製作
            </div>
        </div>
    </div>
    </form>
</body>
</html>
