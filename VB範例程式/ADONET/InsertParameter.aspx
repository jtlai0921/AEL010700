<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InsertParameter.aspx.vb"
    Inherits="InsertParameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="Images/Insert.gif" alt="" /><br />
        <br />
        產品編號：<asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>
        <br />
        <br />
        產品名稱：<asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
        <br />
        <br />
        產品數量：<asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
        <br />
        <br />
        產品價格：<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnInsert" runat="server" Text="新增產品記錄" />
        <br />
        <br />
        <asp:Literal ID="txtMsg" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
