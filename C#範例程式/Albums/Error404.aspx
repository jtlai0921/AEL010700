<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error404.aspx.cs" Inherits="Error404" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Theme1/Error.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <!--Header -->
        <div id="header">
            <h1 title="這是以ASP.NET及CSS製作的網路相簿">
                夢想家電子相簿</h1>
            <div id="home">
                <a href="Albums.aspx">《首頁》</a> <a href="Admin/AlbumsAdmin.aspx">
                    <asp:Label ID="txtAdmin" runat="server" Text="|《相簿管理》" Visible="False" /></a> <a href="Admin/PhotoUpload.aspx">
                        <asp:Label ID="txtUpload" runat="server" Text="|《相片上載》" 
                    Visible="False" /></a> <a title="相簿管理者登入">
                            <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="loginStatus" LoginText="|《登入》"
                                LogoutText="|《登出》" OnLoggedOut="LoginStatus1_LoggedOut" />
                        </a>
            </div>
        </div>
        <!--Content-->
        <div id="content-404">
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
