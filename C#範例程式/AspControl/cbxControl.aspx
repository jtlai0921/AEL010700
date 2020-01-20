<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cbxControl.aspx.cs" Inherits="cbxControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" Height="60px" 
            ImageUrl="~/Images/Habits.jpg" Width="450px" />
        <br />
        請選擇您的興趣：
        <asp:CheckBoxList ID="cbxHabits" runat="server" RepeatColumns="2" 
            Width="450px" BackColor="#99FF99" BorderStyle="Solid" BorderWidth="1px">
            <asp:ListItem Value="0">打球</asp:ListItem>
            <asp:ListItem Value="1">唱歌</asp:ListItem>
            <asp:ListItem Value="2">看電影</asp:ListItem>
            <asp:ListItem Value="3">騎車</asp:ListItem>
            <asp:ListItem Value="4">看書</asp:ListItem>
            <asp:ListItem Value="5">上網</asp:ListItem>
            <asp:ListItem Value="6">游泳</asp:ListItem>
            <asp:ListItem Value="7">慢跑</asp:ListItem>
            <asp:ListItem Value="8">登山</asp:ListItem>
            <asp:ListItem Value="9">下棋</asp:ListItem>
            <asp:ListItem Value="10">划船</asp:ListItem>
            <asp:ListItem Value="12">玩牌</asp:ListItem>
        </asp:CheckBoxList>
    
        <br />
        <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="確定" />
        <br />
        您選擇的興趣如下：<br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Blue"></asp:Label>
    
    </div>
    </form>
</body>
</html>
