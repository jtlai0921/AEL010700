<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DoLoop.aspx.vb" Inherits="DoLoop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Do...Loop陳述式</h1>
        <asp:Label ID="Label1" runat="server" Text="起始值："></asp:Label>
        <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnGo"
            runat="server" Text="執行Do...Loop" Width="129px" />
        <br />
        <br />
        <asp:TextBox ID="txtMsg" runat="server" Height="382px" TextMode="MultiLine" Width="280px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
