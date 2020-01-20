<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RandFunction.aspx.cs" Inherits="RandFunction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="txtTitle" runat="server" Text="以亂數函數設定字型大小與顏色" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnRand" runat="server" Text="以亂數設定顏色" 
            onclick="btnRand_Click" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
