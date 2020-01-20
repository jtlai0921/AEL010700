<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Albums.aspx.cs" Inherits="Albums" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Theme1/Album.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <!--Header -->
        <div id="header">
            <abbr title="這是以ASP.NET及CSS製作的網路相簿">
                <h1>
                    夢想家電子相簿</h1>
            </abbr>
            <div id="home">
                <a href="Albums.aspx">《首頁》</a> 
                <a href="Admin/AlbumsAdmin.aspx">
                    <asp:Label ID="txtAdmin" runat="server" Text="|《相簿管理》" Visible="False" /></a> 
                <a href="Admin/PhotoUpload.aspx">
                    <asp:Label ID="txtUpload" runat="server" Text="|《相片上載》" Visible="False" /></a> 
                <a title="相簿管理者登入">
                        <asp:LoginStatus ID="LoginStatus1" runat="server" 
                    CssClass="loginStatus" LoginText="|《登入》"
                            LogoutText="|《登出》" onloggedout="LoginStatus1_LoggedOut" />
                </a>
            </div>
        </div>
        <!--Content-->
        <div id="content">
            <div id="content-inside">
                <asp:DataList ID="DataList1" runat="server" DataKeyField="AlbumID" DataSourceID="sqlAlbums"
                    RepeatColumns="5" RepeatDirection="Horizontal" 
                    onitemdatabound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <div id="Picture">
                            <div class="PicBG">
                                <a href='Photos.aspx?AlbumID=<%# Eval("AlbumID") %>&Page=1'>
                                    <img class="PicThumb" src='photos/<%# Eval("DefaultPhotoGUID") %>'  />                                   
                                </a>
                            </div>
                            <asp:Label ID="AlbumIDLabel" runat="server" Text='<%# Eval("AlbumName") %>' />
                            <br />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="sqlAlbums" runat="server" ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>"
                    
                    SelectCommand="with Albums as
                                    (
	                                    select *,
	                                    Row_Number() Over (order by AlbumID) AS 'RowNumber'
	                                    from AlbumData 
                                    )

                                    Select * from Albums where RowNumber Between (( @paramPage - 1 ) * 15 + 1)  And 
                                    ((@paramPage - 1 ) * 15 + 15)  " 
                    
                    
                    
                    ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>" 
                    onselected="sqlAlbums_Selected">
                    <SelectParameters>
                        <asp:QueryStringParameter DbType="Int16" DefaultValue="1" Name="paramPage" QueryStringField="Page" />
                        <asp:QueryStringParameter DefaultValue="5" Name="paramPageSize" QueryStringField="PageSize" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <div id="pager">
                    <asp:Panel ID="plPager" runat="server">
                    </asp:Panel>
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
