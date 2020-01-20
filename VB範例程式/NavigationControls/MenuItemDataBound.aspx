<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuItemDataBound.aspx.vb" Inherits="MenuItemDataBound" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DataSourceID="SiteMapDataSource1"
                DynamicHorizontalOffset="2" EnableTheming="False" Font-Names="Verdana" Font-Size="0.8em"
                ForeColor="#990000" MaximumDynamicDisplayLevels="2" StaticSubMenuIndent="10px">
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                <DynamicMenuStyle BackColor="#FFFBD6" />
                <StaticSelectedStyle BackColor="#FFCC66" />
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            </asp:Menu>
            &nbsp;</div>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    
    </div>
    </form>
</body>
</html>
