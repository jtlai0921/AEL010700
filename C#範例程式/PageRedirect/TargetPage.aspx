<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TargetPage.aspx.cs" Inherits="TargetPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Target.jpg" />
        <br />
        Server.Transfer方法導向目標網頁成功！<br />
        <br />
        <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="回上一頁" />
    
    </div>
    </form>
</body>
</html>
