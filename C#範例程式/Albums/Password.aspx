<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Password.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Theme1/Password.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="txtPassword" defaultbutton="btnPassword" >
    <div id="wrapper">
        <!--Header -->
        <div id="header">
            <h1 title="這是以ASP.NET及CSS製作的網路相簿">
                夢想家電子相簿</h1>
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
            <div id="loginStyle">
            <img src="Images/iSpherePlus256.png" />
                <br />
                相簿已設定密碼保護，必須輸入密碼才能瀏覽相簿！<br />
                <div id="pwdStyle">
                密碼：
                <asp:TextBox ID="txtPassword" runat="server" AutoCompleteType="Disabled" />

                <asp:ImageButton ID="btnPassword" runat="server" 
                    ImageUrl="~/Images/Password.png" onclick="btnPassword_Click" />
                    <asp:SqlDataSource ID="sqlAlbumPwd" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:AlbumDBConnectionString1 %>" 
                        onselected="sqlAlbumPwd_Selected" 
                        
                        ProviderName="<%$ ConnectionStrings:AlbumDBConnectionString1.ProviderName %>" 
                        
                        SelectCommand="SELECT TOP (1) AlbumID,AlbumName FROM AlbumData
                        where AlbumID=@paramAlbumID and  Password=@paramPwd 
                        and protection='True' and Password!='' and Password is not null">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="paramAlbumID" QueryStringField="AlbumID" />
                            <asp:ControlParameter ControlID="txtPassword" Name="paramPwd" 
                                PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    
                    <asp:Label ID="txtMsg" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                    <br />
            </div>
            <img src="Images/iconKey.png" /></div>

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
