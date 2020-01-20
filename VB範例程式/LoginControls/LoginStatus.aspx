<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginStatus.aspx.vb" Inherits="LoginStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LoginStatus ID="LoginStatus1" runat="server" LoginImageUrl="~/Images/LoginImg.png"
            LogoutAction="RedirectToLoginPage" 
            LogoutImageUrl="~/Images/LogoutImg.png" />
        <br />
        <asp:LoginName ID="LoginName1" runat="server" FormatString="您登入的帳號是：{0}" />
    
    </div>
    </form>
</body>
</html>
