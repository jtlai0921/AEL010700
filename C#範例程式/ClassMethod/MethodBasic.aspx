<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MethodBasic.aspx.cs" Inherits="MethodBasic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>方法的建立與使用</h2>
        請輸入阿拉伯數字：<asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnConvert" runat="server" OnClick="btnConvert_Click" Text="轉換為中文字" />
        <br /><br />
        <asp:Label ID="txtMsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
