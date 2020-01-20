<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WhileStatement.aspx.vb"
    Inherits="WhileStatement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            While...End While陳述式</h1>
        請選擇您的身高：&nbsp;
        <asp:DropDownList ID="dwnHeight" runat="server" AutoPostBack="True"
            Width="150px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
