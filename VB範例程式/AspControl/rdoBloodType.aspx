<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rdoBloodType.aspx.vb"
    Inherits="rdoBloodType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" Height="60px" ImageUrl="~/Images/Blood.jpg"
            Width="300px" />
        <br />
        <asp:RadioButtonList ID="rdoBlood" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoBlood_SelectedIndexChanged"
            RepeatDirection="Horizontal" ToolTip="請選擇血型">
            <asp:ListItem Value="0">A型</asp:ListItem>
            <asp:ListItem Value="1">B型</asp:ListItem>
            <asp:ListItem Value="2">O型</asp:ListItem>
            <asp:ListItem Value="3">AB型</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Blue"></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
