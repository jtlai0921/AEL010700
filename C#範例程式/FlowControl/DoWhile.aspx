<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoWhile.aspx.cs" Inherits="DoWhile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" Height="60px" 
            ImageUrl="~/Images/dowhille.jpg" Width="450px" />
        <br /><br />
    
        <asp:Label ID="Label1" runat="server" Text="起始值："></asp:Label>
        <asp:TextBox ID="txtStart" runat="server"></asp:TextBox><asp:Button ID="btnGo" 
            runat="server" onclick="Button1_Click" Text="執行" Width="100px" />
        <br />
        <br />
        <asp:TextBox ID="txtMsg" runat="server" Height="382px" TextMode="MultiLine" 
        Width="280px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
