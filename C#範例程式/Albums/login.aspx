<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Theme1/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <!--Header -->
        <div id="header">
            <h1 title="這是以ASP.NET及CSS製作的網路相簿">
                夢想家電子相簿</h1>
            <div id="home"><a href="Albums.aspx" >《首頁》</a></div>
        </div>
        <!--Content-->
        <div id="content">
            <div id="loginStyle">
                <asp:Login ID="Login1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
                    ForeColor="#333333" TextLayout="TextOnTop" 
                    DestinationPageUrl="~/Admin/AlbumsAdmin.aspx">
                    <TextBoxStyle Font-Size="0.8em" />
                    <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                    <LayoutTemplate>
                        <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0">
                                        <tr>
                                            <td align="center" style="color: White; background-color: #990000; font-size: 0.9em;
                                                font-weight: bold;">
                                                登入
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">使用者名稱:</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em" Width="150px" 
                                                    BorderColor="#00CCFF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="必須提供使用者名稱。" ToolTip="必須提供使用者名稱。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密碼:</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password" 
                                                    Width="150px" BorderColor="#00CCFF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                    <br />
                                                    <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#CC9966"
                                                    BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana"
                                                    Font-Size="0.8em" ForeColor="#990000" Text="登入" ValidationGroup="Login1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <br /><br /><br />
                                                <asp:CheckBox ID="RememberMe" runat="server" Text="記憶密碼供下次使用。" 
                                                    CssClass="labelStyle" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                </asp:Login>
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
