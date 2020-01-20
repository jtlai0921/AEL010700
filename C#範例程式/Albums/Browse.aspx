<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Theme1/Browse.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <!--Header
        <div id="header">
            <abbr title="這是以ASP.NET及CSS製作的網路相簿">
                <h1>
                    夢想家電子相簿</h1>
            </abbr>
            <div id="home">
                <a href="Albums.aspx">《首頁》</a> 
                <a href="Admin/AlbumsAdmin.aspx">
                    <asp:Label ID="txtAdmin" runat="server" Text="|《相簿管理》" /></a> 
                <a href="Admin/PhotoUpload.aspx">
                    <asp:Label ID="txtUpload" runat="server" Text="|《相片上載》" /></a> 
                <a title="相簿管理者登入">
                        <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="loginStatus" LoginText="|《登入》"
                            LogoutText="|《登出》" />
                </a>
            </div>
        </div> -->       
                    
            <div id="navigation">        
                <div id="nav-home">
                    <asp:ImageButton ID="btnHome" runat="server" ImageUrl="~/Images/iconHome.png" 
                        ToolTip="回首頁" PostBackUrl="~/Albums.aspx" />

                    <asp:ImageButton ID="btnPhotos" runat="server" ImageUrl="~/Images/iconAlbum.png" 
                        onclick="btnAlbum_Click" ToolTip="回上一層相簿" />
                </div>
                <!--Button按鈕-->
                <div id="navi-button">
                    <asp:ImageButton ID="btnFirst" runat="server" AlternateText="第一張" 
                        ImageUrl="~/Images/btnFirst.png" onclick="btnFirst_Click" />
                    <asp:ImageButton ID="btnPrevious" runat="server" AlternateText="前一張" 
                        ImageUrl="Images/btnPrevious.png" onclick="btnPrevious_Click" />
                    <asp:ImageButton ID="btnNext" runat="server" AlternateText="下一張" 
                        ImageUrl="Images/btnNext.png" onclick="btnNext_Click" />
                    <asp:ImageButton ID="btnLast" runat="server" AlternateText="最末張" 
                        ImageUrl="~/Images/btnLast.png" onclick="btnLast_Click" />
                </div>
                <div id="nav-right">
                    <!--<asp:ImageButton ID="btnAlbum0" runat="server" ImageUrl="Images/btnAlbum.png" />-->
                </div>
            </div>
         <!--Content-->
        <div id="content">
                    <!--照片索引/照片總數-->
            <div id="photoIndex">
                <asp:Label ID="txtCurrentIndex" runat="server"></asp:Label>
                <asp:Literal ID="txtSeperator" runat="server" Text=" / " Visible="False"></asp:Literal>
                <asp:Label ID="txtTotalRows" runat="server" Text=""></asp:Label>
                <asp:Label ID="txtAlbumName" runat="server" Text=""></asp:Label>
            </div>
            <div id="content-inside">

                <asp:DataList ID="dlPhotos" runat="server" DataSourceID="sqlPhotoData" 
                    RepeatDirection="Horizontal" 
                    onitemdatabound="dlPhotos_ItemDataBound" RepeatColumns="7">
                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                    <HeaderTemplate>
                        <!--全尺寸主相片-->
                        <div id="fullImageStyle">
                            <asp:ImageButton ID="fullImage" runat="server" 
                                onclick="fullImage_Click" BorderColor="#E2E2E2" BorderStyle="Solid" 
                                BorderWidth="1" Visible="True" />
                            <br />
                            <asp:Literal ID="txtDesc" runat="server"></asp:Literal>
                        </div>
                            <br />
                            <hr />
                            <br />  
                        <div id="navi-Photos"></div>
                    </HeaderTemplate>
                    <FooterTemplate>
                        
                        <br />
                        <hr />

                    </FooterTemplate>
                                            
                    <ItemTemplate>
                               <!--相片導覽列-->
                               <asp:ImageButton ID="btnNavi" runat="server" 
                                    ImageUrl='<%# String.Format("photos/{0}",Eval("PhotoGUID"))%>' 
                                    onclick="btnNavi_Click" CssClass="Photo"  
                                    ToolTip='<%# String.Format("{0}",Eval("Description")).Trim()%>'  
                                     /><br />
                                <asp:Literal ID="txtDescription" runat="server" 
                                    Text='<%# Eval("Description") %>' />
                         
                    </ItemTemplate>

                </asp:DataList>
               <asp:SqlDataSource ID="sqlPhotoData" runat="server" ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>"
                    SelectCommand="With Albums AS
(
	select *,Row_Number() Over (order by UploadTime) AS 'RowNumber'
	from PhotoData 
                  where AlbumID =(Select AlbumID from PhotoData Where PhotoGUID=@paramPhotoGUID)
)
Select * from Albums 
where RowNumber between @paramIndex-@leftOffset and @paramIndex+@rightOffset;" 
                    
                    
                    
                    
                    ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="paramPhotoGUID" QueryStringField="PhotoGUID" />
                        <asp:ControlParameter ControlID="txtTotalRows" DbType="Int16" DefaultValue="" 
                            Name="paramRows" PropertyName="Text" />
                        <asp:ControlParameter ControlID="txtCurrentIndex" DbType="Int16" 
                            DefaultValue="" Name="paramIndex" PropertyName="Text" />
                        <asp:Parameter DbType="Int16" DefaultValue="" Name="leftOffset" />
                        <asp:Parameter DbType="Int16" DefaultValue="" Name="rightOffset" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlRowsCount" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                    ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>" 
                    SelectCommand="--1.依PhotoGUID取得AlbumID，再計算PhotoData資料表中該相簿的Rows總筆數
Select count(*) as TotalRows  from PhotoData where AlbumID =(Select AlbumID from PhotoData Where PhotoGUID=@paramPhotoGUID);

--2.取得特定PhotoGUID在整個資料列中的編號
With Photos AS
(
	select PhotoGUID,Description,AlbumID,Row_Number() Over (order by UploadTime) AS 'RowNumber'
	from PhotoData
                  where AlbumID =(Select AlbumID from PhotoData Where PhotoGUID=@paramPhotoGUID)
)
Select PhotoGUID,Description,AlbumID,RowNumber from Photos where  PhotoGUID=@paramPhotoGUID;">
                    <SelectParameters>
                        <asp:QueryStringParameter DbType="String" DefaultValue="" Name="paramPhotoGUID" 
                            QueryStringField="PhotoGUID" />
                    </SelectParameters>
                </asp:SqlDataSource>
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
