<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuMode.aspx.cs" Inherits="MenuMode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>靜態與動態Menu功能表選單</h2>
        <table>
            <tr>
                <td style="width: 100px">
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DataSourceID="SiteMapDataSource1"
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000"
            StaticSubMenuIndent="10px" EnableTheming="False" BorderColor="Black" 
                        BorderStyle="Dashed" StaticDisplayLevels="3" BorderWidth="1px" 
                        MaximumDynamicDisplayLevels="1" Width="142px">
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <StaticSelectedStyle BackColor="#FFCC66" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        </asp:Menu>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Menu ID="Menu2" runat="server" BackColor="#E3EAEB" BorderColor="#404040" BorderStyle="Dashed"
                        BorderWidth="2px" DataSourceID="SiteMapDataSource1" DynamicHorizontalOffset="2"
                        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" 
                        StaticSubMenuIndent="10px">
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                        <DynamicMenuStyle BackColor="#E3EAEB" />
                        <StaticSelectedStyle BackColor="#1C5E55" />
                        <DynamicSelectedStyle BackColor="#1C5E55" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                    </asp:Menu>
                </td>
            </tr>
        </table>
    </div>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </form>
</body>
</html>
