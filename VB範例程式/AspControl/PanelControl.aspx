<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PanelControl.aspx.vb" Inherits="PanelControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" Height="60px" ImageUrl="~/Images/Panel.jpg"
            Width="450px" />
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="250px"
            Width="450px">
        </asp:Panel>
        <asp:Button ID="btnAdd" runat="server" Text="加入控制項" />
    </div>
    </form>
</body>
</html>
