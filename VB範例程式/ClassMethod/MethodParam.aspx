﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MethodParam.aspx.vb" Inherits="MethodParam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>呼叫含參數的方法，計算三角形斜邊長度</h2>
        a的長度：<asp:TextBox ID="txtA" runat="server"></asp:TextBox>
        <br />
        <br />
        b的長度：<asp:TextBox ID="txtB" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCal" runat="server" OnClick="btnCal_Click" Text="計算斜邊c的長度" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
