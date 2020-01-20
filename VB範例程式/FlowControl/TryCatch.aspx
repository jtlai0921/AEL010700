<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TryCatch.aspx.vb" Inherits="TryCatch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            Try...Catch例外狀況處理</h2>
        <asp:TextBox ID="txtNumerator" runat="server"></asp:TextBox>
        &nbsp; /&nbsp;
        <asp:TextBox ID="txtDenominator" runat="server"></asp:TextBox>
        &nbsp; =
        <asp:Label ID="txtResult" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnDiv1" runat="server" Text="除法計算（無Try...Catch）"
            Width="250px" />&nbsp;&nbsp;
        <asp:Button ID="btnDiv2" runat="server" Text="除法計算（有Try...Catch）"
            Width="250px" />
    </div>
    </form>
</body>
</html>
