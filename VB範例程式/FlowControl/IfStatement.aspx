<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IfStatement.aspx.vb" Inherits="IfStatement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
        <h1>If陳述式的運用</h1>
        <asp:Label ID="capScore" runat="server" Text="請輸入英文成績："></asp:Label>
        <asp:TextBox ID="txtScore" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnOK" runat="server" Text="判斷成績是否及格" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" BorderColor="Blue"></asp:Label>
    </div>
    </form>
</body>
</html>
