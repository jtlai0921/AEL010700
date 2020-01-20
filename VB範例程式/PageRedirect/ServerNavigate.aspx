<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ServerNavigate.aspx.vb"
    Inherits="ServerNavigate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Server.jpg" />
        <br />
        <br />
        <asp:Button ID="btnRedirect" runat="server" OnClick="btnRedirect_Click" Text="Response.Redirect()"
            Width="200px" />
        <br />
        <br />
        <asp:Button ID="btnTransfer" runat="server" OnClick="btnTransfer_Click" Text="Server.Transfer()"
            Width="200px" />
    </div>
    </form>
</body>
</html>
