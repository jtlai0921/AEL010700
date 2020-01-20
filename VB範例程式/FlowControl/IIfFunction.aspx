<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IIfFunction.aspx.vb" Inherits="IIfFunction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>以IIf函數判斷成績是否及格</h2>
        請輸入英文成績：<asp:TextBox ID="txtScore" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnOK" runat="server" Text="判斷成績是否及格" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
