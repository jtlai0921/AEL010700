<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DwnControl.aspx.cs" Inherits="DwnControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2>請選擇居住地點</h2>
        <hr align="left" width="500" />
        <asp:Label ID="capRegion" runat="server" Text="地區："></asp:Label>
        <asp:DropDownList ID="dwnRegion" runat="server" Width="200px" 
            AutoPostBack="True" onselectedindexchanged="dwnRegion_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="0">===請選擇居住地區===</asp:ListItem>
            <asp:ListItem Value="1">美國</asp:ListItem>
            <asp:ListItem Value="2">大陸</asp:ListItem>
            <asp:ListItem Value="3">台灣</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="capCity" runat="server" Text="城市："></asp:Label>
        <asp:DropDownList ID="dwnCity" runat="server" Width="200px" AutoPostBack="True" 
            onselectedindexchanged="dwnCity_SelectedIndexChanged">
        </asp:DropDownList>
    
        <br />
        <br />
        <br />
        <br />
        <br />
        您居住的地點為：<asp:Label ID="txtMsg" runat="server" ForeColor="Blue"></asp:Label>
    
    </div>
    </form>
</body>
</html>
