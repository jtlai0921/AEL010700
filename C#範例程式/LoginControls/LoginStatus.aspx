<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginStatus.aspx.cs" Inherits="LoginStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LoginStatus ID="LoginStatus1" runat="server" LoginImageUrl="~/Images/LoginImg.png"
            LogoutAction="RedirectToLoginPage" 
            LogoutImageUrl="~/Images/LogoutImg.png" />
        <br />
        <asp:LoginName ID="LoginName1" runat="server" FormatString="您登入的帳號是：{0}" />
    </form>
</body>
</html>
