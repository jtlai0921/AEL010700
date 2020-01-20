<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhotoUpload.aspx.cs" Inherits="PhotoUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/Theme1/uploadStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <!--Header -->
        <div id="header">
            <h2>夢想家電子相簿</h2>
            <div id="home">
                <a href="../Albums.aspx" >《首頁》</a>
                <a href="AlbumsAdmin.aspx" >|《相簿管理》</a>
                <a>
                <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="loginStatus" 
                    LoginText="|《登入》" LogoutText="|《登出》" 
                    onloggedout="LoginStatus1_LoggedOut" /></a>
            </div>
        </div>
        <!--Content-->
        <div id="content">
            <div id="content-inside">
                請選擇相簿：<asp:DropDownList ID="dwnAlbum" runat="server" Height="25px" Width="170px"
                    AppendDataBoundItems="True" DataSourceID="sqlAlbums" 
                    DataTextField="AlbumName" DataValueField="AlbumID">
                    <asp:ListItem Value="0">===請選擇相簿===</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="dwnAlbum" ErrorMessage="*請選擇上載相簿名稱" InitialValue="0"></asp:RequiredFieldValidator>
                <br />
                <asp:SqlDataSource ID="sqlAlbums" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                    SelectCommand="SELECT [AlbumID], [AlbumName] FROM [AlbumData]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlPhotoData" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                    InsertCommand="INSERT INTO PhotoData(PhotoGUID, FileName, AlbumID,UploadTime) VALUES (@paramGUID, @paramFileName, @paramAlbumID,@paramUploadTime)" 
                    
                    ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>">
                    <InsertParameters>
                        <asp:Parameter Name="paramGUID" />
                        <asp:Parameter Name="paramFileName" />
                        <asp:ControlParameter ControlID="dwnAlbum" Name="paramAlbumID" 
                            PropertyName="SelectedValue" />
                        <asp:Parameter DbType="DateTime" Name="paramUploadTime" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <hr />
                <ul id="uploadItem">
                    <li>01.<asp:FileUpload ID="FileUpload1" runat="server" CssClass="uploadControl" /></li>
                    <li>02.<asp:FileUpload ID="FileUpload2" runat="server" CssClass="uploadControl" /></li>
                    <li>03.<asp:FileUpload ID="FileUpload3" runat="server" CssClass="uploadControl" /></li>
                    <li>04.<asp:FileUpload ID="FileUpload4" runat="server" CssClass="uploadControl" /></li>
                    <li>05.<asp:FileUpload ID="FileUpload5" runat="server" CssClass="uploadControl" /></li>
                    <li>06.<asp:FileUpload ID="FileUpload6" runat="server" CssClass="uploadControl" /></li>
                    <li>07.<asp:FileUpload ID="FileUpload7" runat="server" CssClass="uploadControl" /></li>
                    <li>08.<asp:FileUpload ID="FileUpload8" runat="server" CssClass="uploadControl" /></li>
                    <li>09.<asp:FileUpload ID="FileUpload9" runat="server" CssClass="uploadControl" /></li>
                    <li>10.<asp:FileUpload ID="FileUpload10" runat="server" CssClass="uploadControl" /></li>
                </ul>
                <br />
                <hr />
                <asp:ImageButton ID="btnUpload" runat="server" 
                    ImageUrl="~/Images/UploadButton.png" onclick="btnUpload_Click" />
                <br />
                <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label><br />
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
