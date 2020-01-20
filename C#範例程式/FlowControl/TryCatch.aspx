<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryCatch.aspx.cs" Inherits="TryCatch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            try...catch例外狀況處理</h2>
        <asp:TextBox ID="txtNumerator" runat="server"></asp:TextBox>
        &nbsp; /&nbsp;
        <asp:TextBox ID="txtDenominator" runat="server"></asp:TextBox>
        &nbsp; =
        <asp:Label ID="txtResult" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnDiv1" runat="server" Text="除法計算（無try...catch）" OnClick="btnDiv1_Click"
            Width="250px" />&nbsp;&nbsp;
        <asp:Button ID="btnDiv2" runat="server" OnClick="btnDiv2_Click" Text="除法計算（有try...catch）"
            Width="250px" />
    </div>
    </form>
</body>
</html>
