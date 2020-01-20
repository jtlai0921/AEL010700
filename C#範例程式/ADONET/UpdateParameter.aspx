<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateParameter.aspx.cs" Inherits="UpdateParameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Update.gif" />
        <br />
        產品編號：<asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>
        <br />
        <br />
        產品名稱：<asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
        <br />
        <br />
        產品庫存：<asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
        <br />
        <br />
        產品價格：<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="更新產品記錄" 
            onclick="btnUpdate_Click" />
    
        <br />
        <br />
        <asp:Literal ID="txtMsg" runat="server"></asp:Literal>
    
    </div>
    </form>
</body>
</html>
