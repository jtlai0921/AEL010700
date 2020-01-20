<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InputData.aspx.vb" Inherits="InputData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        請輸入帳號/密碼，及留言！<hr />
        <br />
        <asp:Label ID="capID" runat="server" Text="帳號："></asp:Label>
        <asp:TextBox ID="txtID" runat="server" Width="150px"></asp:TextBox>
        <br />
        <asp:Label ID="capPassword" runat="server" Text="密碼："></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
        <br />
        <br />
        留言：<br />
        <br />
        <asp:TextBox ID="txtMsg" runat="server" BorderStyle="Solid" Height="235px" TextMode="MultiLine"
            Width="370px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="確定" />
    </div>
    </form>
</body>
</html>
