<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwitchCase.aspx.cs" Inherits="SwitchCase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" Height="60px" 
            ImageUrl="~/Images/swtich.jpg" Width="450px" />
        <br />
        <br />
        <asp:Label ID="capJob" runat="server" Text="職務："></asp:Label>
        <asp:DropDownList ID="dwnJob" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="150px">
            <asp:ListItem Value="0">==請選擇職務==</asp:ListItem>
            <asp:ListItem Value="1">總經理</asp:ListItem>
            <asp:ListItem Value="2">經理</asp:ListItem>
            <asp:ListItem Value="3">工程師</asp:ListItem>
            <asp:ListItem Value="4">助理</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="txtSalary" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
