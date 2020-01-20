<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CrossPageSource.aspx.vb"
    Inherits="CrossPageSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>跨網頁公布（來源）</h2>
        <asp:Label ID="capUserName" runat="server" Font-Size="12pt" Text="請輸入姓名："></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server" Font-Size="12pt"></asp:TextBox>
        <asp:Button ID="btnOK" runat="server" Text="確定" PostBackUrl="~/CrossPageTarget.aspx" />
    </div>
    </form>
</body>
</html>
